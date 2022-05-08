using System.Diagnostics;
class CoreCommands
{
    static string ExecShellCommand(string command, string arguments = "")
    {
        ProcessStartInfo psi; // объявляем переменную с информацией о процессе.

        if(arguments != "")
        {
            psi = new ProcessStartInfo(command, arguments); // передаем команду процесса.
        }
        else
        {
            psi = new ProcessStartInfo(command); // передаем команду процесса.
        }

        psi.UseShellExecute = false; // переводим программу в CLI режим.
        psi.RedirectStandardOutput = true; // разрешаем читать вывод процесса.

        Process _process = new Process(); // создаем процесс.

        _process.StartInfo = psi; // передаем конфигурацию процесса.
        _process.Start(); // запускаем процесс.

        string output = _process.StandardOutput.ReadToEnd(); // сохраняем вывод в переменную.
        return output;
    }
}