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
        private readonly SerialPort _serialPort = new SerialPort("COM3", 9600);

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
                _serialPort.NewLine = "\r\n";
                _serialPort.Open();
                _serialPort.DataReceived += (sender, e) => { NextData = ((SerialPort) sender).ReadByte(); };
            }
            catch
            {
                // ignored
            }
        }

        public void PortDispose()
        {
            if(_serialPort.IsOpen) _serialPort.Close();
            _serialPort.Dispose();
        }
    }
}
