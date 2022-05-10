using System.Text.RegularExpressions;

class USBDevice
{
    public static List<string> GetList()
    {
        var devicesListFromLsbls = CoreCommands.ExecShellCommand("lsblk", "--output NAME --noheadings --nodeps");

        return Regex.Replace(devicesListFromLsbls, "sr[0-9]|cdrom[0-9]", "")
            .Split()
            .Where(IsRemovable)
            .Select(x => "/dev/" + x)
            .ToList();
    }

    public static string GetUsbDeviceCapacity(string device)
    {
        var returned = "Empty device variable";

        if (device != "")
        {
            var output = CoreCommands.ExecShellCommand("lsblk", "--output SIZE --noheadings --nodeps " + device)
                .Trim();
            if(output != "")
            {
                returned = output;
            }
            else
            {
                returned = "Not found device";
            }
        }
        else
        {
            returned = "Empty device variable";
        }
        return returned;
    }

    public static string GetUsbDeviceModel(string device)
    {
        var returned = "Empty device variable";

        if (device != "")
        {
            var output = CoreCommands.ExecShellCommand("lsblk", "--output MODEL --noheadings --nodeps " + device)
                .Trim();
            if(output != "")
            {
                returned = output;
            }
            else
            {
                returned = "Not found device";
            }
        }
        else
        {
            returned = "Empty device variable";
        }
        return returned;
    }

    public static bool IsMounted(string device)
    {
        var returned = device != "" ? CoreCommands.ExecShellCommand("df").Contains(device) : false;
        return returned;
    }

    public static bool IsRemovable(string device)
    {
        var returnedValue = false;

        var sysfsBlockDeviceDir = "/sys/block/" + device;

        if (File.Exists(sysfsBlockDeviceDir + "/removable"))
        {
            var removableContent = File.ReadAllText("/sys/block/" + device + "/removable").Trim();
           // var ro_content = File.ReadAllText("/sys/block/" + device + "/ro").Trim();

           returnedValue = removableContent == "1";
        }

        return returnedValue;
    }
}