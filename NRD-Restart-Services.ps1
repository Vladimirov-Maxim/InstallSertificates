# Путь к лог-файлу (укажите свой)
$LogPath = "C:\Logs\service_restart.log"

# Список имён служб для перезапуска (указывайте точные имена служб, как в 'Get-Service')
$ServiceNames = @(
    "postgresql-x64-16"
)

# Функция для записи в лог
function Write-Log {
    param([string]$Message)
    $Timestamp = Get-Date -Format "yyyy-MM-dd HH:mm:ss"
    $LogEntry = "[$Timestamp] $Message"
    Add-Content -Path $LogPath -Value $LogEntry -Encoding UTF8
    Write-Host $LogEntry  # Также выводим в консоль
}

# Создаём папку для лога, если её нет
$LogDir = Split-Path $LogPath -Parent
if (!(Test-Path $LogDir)) {
    New-Item -ItemType Directory -Path $LogDir -Force | Out-Null
}

Write-Log "=== Начало перезапуска служб ==="

foreach ($ServiceName in $ServiceNames) {
    Write-Log "Обработка службы: $ServiceName"

    # Проверяем, существует ли служба
    $Service = Get-Service -Name $ServiceName -ErrorAction SilentlyContinue
    if (-not $Service) {
        Write-Log "  ❌ Служба '$ServiceName' не найдена. Пропускаем."
        continue
    }

    # Останавливаем службу
    try {
        if ($Service.Status -eq "Running") {
            Write-Log "  ⏹️  Останавливаем службу..."
            Stop-Service -Name $ServiceName -Force -ErrorAction Stop
            Write-Log "  ✅ Служба остановлена."
        } else {
            Write-Log "  ℹ️  Служба уже остановлена или не запущена."
        }
    }
    catch {
        Write-Log "  ❌ Ошибка при остановке: $($_.Exception.Message)"
    }

    # Запускаем службу
    try {
        Write-Log "  ▶️  Запускаем службу..."
        Start-Service -Name $ServiceName -ErrorAction Stop
        Write-Log "  ✅ Служба успешно запущена."
    }
    catch {
        Write-Log "  ❌ Ошибка при запуске: $($_.Exception.Message)"
    }
}

Write-Log "=== Перезапуск завершён ==="
Write-Host "`nЛог сохранён в: $LogPath"