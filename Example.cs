class Example
{
    static void Main()
    {
        var text = USBDevice.GetList();
        var cap = USBDevice.GetUsbDeviceCapacity("/dev/sdb");
        var model = USBDevice.GetUsbDeviceModel("/dev/sdb");
        Console.WriteLine("Device: " + text[0]);
        Console.WriteLine("Capacity: " + cap);
        Console.WriteLine("Model: " + model);
    }
}
