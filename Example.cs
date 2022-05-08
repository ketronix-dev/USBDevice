class Example
{
    static void Main()
    {
        List<string> text = USBDevice.GetList();
        string cap = USBDevice.GetUSBDeviceCapacity("/dev/sdb");
        string model = USBDevice.GetUSBDeviceModel("/dev/sdb");
        Console.WriteLine(text[0]);
        Console.WriteLine(cap);
        Console.WriteLine(model);
    }
}