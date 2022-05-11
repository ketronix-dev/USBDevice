class Example
{
    static void Main()
    {
        var text = USBDevice.GetList();
        var cap = USBDevice.GetUsbDeviceCapacity("/dev/sdb");
        var model = USBDevice.GetUsbDeviceModel("/dev/sdb");
        var ismounted = USBDevice.IsMounted("/dev/sdb");
        var device = text.Count == 0 ? "Not Found":text[0];
        Console.WriteLine("Device: " + device);
        Console.WriteLine("Capacity: " + cap);
        Console.WriteLine("Model: " + model);
        Console.WriteLine("Mounted: " + ismounted);

        /** Requiret root
        int outputUmount = USBDevice.UnmountDevice("/dev/sdb1");
        Console.WriteLine(outputUmount);
        int outputMount = USBDevice.MountDevice("/dev/sdb1", "/mnt");
        Console.WriteLine(outputMount); 
        **/
    }
}
