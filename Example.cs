using GetUSBDevice;

class Example
{
    static void Main()
    {
<<<<<<< Updated upstream
        var text = USBDevice.GetList();
        var cap = USBDevice.GetUsbDeviceCapacity("/dev/sdb");
        var model = USBDevice.GetUsbDeviceModel("/dev/sdb");
        Console.WriteLine(text[0]);
        Console.WriteLine(cap);
        Console.WriteLine(model);
=======
        List<string> text = USBDevice.GetList();
        string cap = USBDevice.GetUSBDeviceCapacity("/dev/sdb");
        string model = USBDevice.GetUSBDeviceModel("/dev/sdb");
        Console.WriteLine("Device: " + text[0]);
        Console.WriteLine("Capacity: " + cap);
        Console.WriteLine("Model: " + model);
>>>>>>> Stashed changes
    }
}
