using System.Diagnostics;
class CoreCommands
{
    public static string ExecShellCommand(string command, string arguments = "")
    {
        ProcessStartInfo psi; // объявляем переменную с информацией о процессе.

        if(arguments != "") // проверяем, пустой ли аргумент
        {
            psi = new ProcessStartInfo(command, arguments); // если аргументы есть - добавить аргументы в команду процесса
        }
        else
        {
            psi = new ProcessStartInfo(command); // Если аргументов нет - добавляем только команду.
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