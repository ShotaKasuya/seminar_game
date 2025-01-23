using System;
using System.IO.Ports;

namespace Module.Serial
{
    public class SerialPortManager : IPortWritable, IPortInitializable, IDisposable
    {
        public void InitializePort(SerialPort serialPort)
        {
            serialPort.Open();
            Port = serialPort;
        }

        public void RenamePort(string name)
        {
            Port.PortName = name;
        }

        public void Write(Finger finger)
        {
            var ifinger = (int)finger;
            Port.Write(ifinger.ToString());
        }

        private SerialPort Port { get; set; }

        public void Dispose()
        {
            Port?.Dispose();
        }
    }
}