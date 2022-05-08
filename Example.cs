using GetUSBDevice;

class Example
{
    static void Main()
    {
        var text = USBDevice.GetList();
        var cap = USBDevice.GetUsbDeviceCapacity("/dev/sdb");
        var model = USBDevice.GetUsbDeviceModel("/dev/sdb");
        Console.WriteLine(text[0]);
        Console.WriteLine(cap);
        Console.WriteLine(model);
    }
}