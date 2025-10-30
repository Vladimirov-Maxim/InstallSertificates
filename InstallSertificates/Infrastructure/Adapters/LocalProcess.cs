using System.Diagnostics;
using System.Text;

namespace InstallSertificates.Infrastructure.Adapters
{
    public class LocalProcess
    {
        public static ProcessResult StartProcess(ProcessStartInfo startInfo, string? OutFile = null)
        {

            var processResult = new ProcessResult();

            var ansi866 = Encoding.GetEncoding(866);
            startInfo.StandardOutputEncoding = ansi866;
            startInfo.StandardErrorEncoding = ansi866;

            try
            {
                var process = Process.Start(startInfo);

                if (process == null)
                    throw new InvalidOperationException("Не удалось запустить процесс.");

                if (startInfo.RedirectStandardOutput)
                {
                    string out_text = process.StandardOutput.ReadToEnd();
                    processResult.out_text = out_text;
                }

                if (startInfo.RedirectStandardError)
                {
                    string err_text = process.StandardError.ReadToEnd();
                    processResult.err_text = err_text;
                }

                process.WaitForExit();

                processResult.code = process.ExitCode;

                if (OutFile != null)
                {
                    using (var reader = new StreamReader(OutFile))
                    {
                        processResult.file_out = reader.ReadToEnd();
                    }
                }

                return processResult;

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Ошибка выполнения процесса Distcontrol:\n{ex.Message}.");
            }

        }

        public struct ProcessResult
       {
            internal string out_text;
            internal string err_text;
            internal string file_out;
            internal int code;

            public ProcessResult()
            {
                out_text = "";
                err_text = "";
                file_out = "";
            }
        }

    }

}
