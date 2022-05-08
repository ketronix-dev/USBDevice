using System.Text.RegularExpressions;

class USBDevice
{
    public static List<string> GetList()
    {
        List<string> device_list = new List<string>();
        //Выполняем системную команду, чтобы получить список устройств.
        string lsblk = CoreCommands.ExecShellCommand("lsblk", "--output NAME --noheadings --nodeps");
        //Возвращаем только те устройства, которые не являются CD/DVD
        string[] devices = Regex.Replace(lsblk , "sr[0-9]|cdrom[0-9]", "").Split();

        foreach (var device in devices)
        {
            if(IsRemovable(device) != false)
            {
                string block_device = "/dev/" + device;

                device_list.Add(block_device);
            }
        }
        return device_list;
    }
    public static string GetUSBDeviceCapacity(string device)
    {
        string device_capacity = CoreCommands.ExecShellCommand("lsblk", "--output SIZE --noheadings --nodeps " + device).Trim();

        return device_capacity;
    }

    public static string GetUSBDeviceModel(string device)
    {
        string device_model = CoreCommands.ExecShellCommand("lsblk", "--output MODEL --noheadings --nodeps " + device).Trim();

        return device_model;
    }

    static bool IsRemovable(string device)
    {
        bool returned_value = false;

        string sysfs_block_device_dir = "/sys/block/" + device;

        if (File.Exists(sysfs_block_device_dir + "/removable"))
        {
            string removable_content = File.ReadAllText("/sys/block/"+device+"/removable").Trim();
            string ro_content = File.ReadAllText("/sys/block/"+device+"/ro").Trim();

            if(removable_content == "1") //& ro_content == "0"
            {
                returned_value = true;
            }
            else
            {
                returned_value = false;
            }
        }
        return returned_value;
    }
}