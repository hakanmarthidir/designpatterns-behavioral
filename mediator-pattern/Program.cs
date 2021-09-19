using System;

namespace mediator_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            FileShareSystem fileShareSystem = new FileShareSystem();

            IDevice device1 = new WindowsDevice() { Name="Win10", Type= DeviceType.Windows, ShareSystem = fileShareSystem };
            IDevice device2 = new WindowsDevice() { Name = "Win11", Type = DeviceType.Windows, ShareSystem = fileShareSystem };
            IDevice device3 = new WindowsDevice() { Name = "MyLaptop", Type = DeviceType.Windows, ShareSystem = fileShareSystem };

            fileShareSystem.Register(device1);
            fileShareSystem.Register(device2);
            fileShareSystem.Register(device3);

            device1.Send(device2.Name, "C:\\abcd.txt");
            device3.Send(device1.Name, "C:\\eeee.txt");
            device2.Send(device3.Name, "C:\\dddd.txt");


        }
    }

}
