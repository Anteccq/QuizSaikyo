using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Reactive.Bindings;

namespace QuizSaikyo.Models
{
    public class SerialManager : BindableBase
    {
        private readonly SerialPort serialPort = new SerialPort("COM3", 9600);

        private int _nextData;
        public int NextData
        {
            get => _nextData;
            set => SetProperty(ref _nextData, value);
        }

        public SerialManager()
        {
            try
            {
                serialPort.NewLine = "\r\n";
                serialPort.Open();
                serialPort.DataReceived += (sender, e) => { NextData = ((SerialPort) sender).ReadByte(); };
            }
            catch
            {
                // ignored
            }
        }

        public void PortDispose()
        {
            if(serialPort.IsOpen) serialPort.Close();
            serialPort.Dispose();
        }
    }
}
