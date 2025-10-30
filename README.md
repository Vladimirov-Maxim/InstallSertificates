# InstallСertificates

Минималистичная утилита для установки сертификатов на токен через CryptoPro и управление подключением USB‑порта через Distcontrol. Внутреннее использование (один сервер, техподдержка).

## Требования
- Установлен CryptoPro CSP (доступны `C:\\Program Files\\Crypto Pro\\CSP\\certmgr.exe` и `csptest.exe`).
- Установлен Distcontrol (доступен `C:\\Program Files\\Distcontrol\\dkcl64.exe`).
- Права на запуск внешних процессов и доступ к USB. При необходимости запускайте от имени администратора.

## Запуск
1. Запустите `InstallСertificates.exe` (можно через `StartAsAdmin.bat` для старта от администратора).
2. В окне:
   - «Обновить» — загрузить уже установленные сертификаты.
   - «…» — выбрать папку с `.cer`.
   - «Заполнить» — загрузить сертификаты из папки.
   - Выберите строку и нажмите «Установить».

Примечания:
- Имя сертификата берётся из Subject (для хранилищ имя отсутствует — поведение осознанное).
- Работа идёт с хранилищем `uMy` и шаблоном контейнера Rutoken по умолчанию.
- Сообщения об ошибках отображаются в окне.

## Сборка (локально)
В корне репозитория выполните:

```powershell
dotnet publish InstallСertificates/InstallСertificates.csproj -c Release -r win-x64 -p:PublishSingleFile=true -p:SelfContained=true -p:PublishTrimmed=false -o publish
Compress-Archive -Path publish/* -DestinationPath InstallСertificates.zip -Force
```

В архиве `InstallСertificates.zip` достаточно одного файла `InstallСertificates.exe` для запуска (остальное не требуется).
