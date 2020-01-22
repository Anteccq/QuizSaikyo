using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.SerialCommunication;
using Windows.Storage.Streams;
using Prism.Mvvm;
using Reactive.Bindings;

namespace QuizSaikyo.Models
{
    public class SerialManager : BindableBase
    {
        private SerialDevice device;
        public DataReader Reader { get; private set; }
        private int _nextData;
        public int NextData
        {
            get => _nextData;
            set => SetProperty(ref _nextData, value);
        }

        public async Task PortInitializeAsync()
        {
            var portData = SerialDevice.GetDeviceSelector("COM3");
            var myDevice = await DeviceInformation.FindAllAsync(portData, null);
            device = await SerialDevice.FromIdAsync(myDevice[0].Id);
            device.BaudRate = 9600;
            device.DataBits = 8;
            device.StopBits = SerialStopBitCount.One;
            device.Parity = SerialParity.None;
            device.Handshake = SerialHandshake.None;
            device.ReadTimeout = TimeSpan.FromMilliseconds(1);
            device.WriteTimeout = TimeSpan.FromMilliseconds(1);
            Observable.Timer(TimeSpan.Zero, TimeSpan.FromMilliseconds(200)).Subscribe(async i =>
            {
                try
                {
                    Reader = new DataReader(device.InputStream);
                    await Reader.LoadAsync(128);
                    var rec = Reader.ReadByte();
                    NextData = rec;
                }
                catch
                {
                    Debug.WriteLine("Error occured");
                }
            });
        }

        public void PortDispose()
        {
            device.Dispose();
            Reader.Dispose();
        }
    }
}
