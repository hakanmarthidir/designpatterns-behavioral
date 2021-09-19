using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mediator_pattern
{
    //1

    public interface IShare
    {
        void Register(IDevice device);
        void SendFile(string from, string to, string filePath);
    }


    public interface IDevice
    {
        string Name { get; set; }
        DeviceType Type { get; set; }
        IShare ShareSystem { get; set; }

        void Send(string to, string filePath);
        void Receive(string from, string filePath);
    }

    public enum DeviceType
    {
        Android,
        IOS,
        Windows,
        Ubuntu
    }

    //2

    public class FileShareSystem : IShare
    {
        private Dictionary<string, IDevice> _deviceList = new Dictionary<string, IDevice>();
        public void Register(IDevice device)
        {
            if (!this._deviceList.ContainsKey(device.Name))
                this._deviceList.Add(device.Name, device);
        }

        public void SendFile(string from, string to, string filePath)
        {
            IDevice device = this._deviceList[to];
            if (device != null)
            {
                device.Receive(from, filePath);
            }

        }
    }

    // 3

    public class WindowsDevice : IDevice
    {
        public string Name { get ; set ; }
        public DeviceType Type { get; set; }
        public IShare ShareSystem { get; set; }

        public void Receive(string from, string filePath)
        {
            Console.WriteLine($"This is {Name} I got a file From : {from}, File : {filePath}");
        }

        public void Send(string to, string filePath)
        {
            this.ShareSystem.SendFile(Name, to, filePath);
        }
    }



}
