using System.Diagnostics;

public static class CoreCommands
{
    public static string ExecShellCommand(string command, string arguments = "")
    {
        var processStartInfo =
            arguments != "" ? new ProcessStartInfo(command, arguments) : new ProcessStartInfo(command);

        // переводим программу в CLI режим.
        processStartInfo.UseShellExecute = false;

        // разрешаем читать вывод процесса.
        processStartInfo.RedirectStandardOutput = true;

        var process = new Process();
        process.StartInfo = processStartInfo;

        process.Start();
        var output = process.StandardOutput.ReadToEnd();

        return output;
    }
}