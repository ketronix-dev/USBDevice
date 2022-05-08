using System.Text.RegularExpressions;

class GetUSBDevice
{
    public static string[] GetList()
    {
        //Выполняем системную команду, чтобы получить список устройств.
        string lsblk = CoreCommands.ExecShellCommand("lsblk", "--output NAME --noheadings --nodeps");
        //Возвращаем только те устройства, которые не являются CD/DVD
        return Regex.Replace(lsblk , "sr[0-9]|cdrom[0-9]", "").Split();
    }
    static void Main()
    {
        
    }
}