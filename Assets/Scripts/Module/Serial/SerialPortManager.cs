using System;
using System.IO.Ports;
using UnityEngine;

namespace Module.Serial
{
    public class SerialPortManager : IPortWritable, IPortInitializable, IDisposable
    {
        public SerialPortManager(SerialPort serialPort)
        {
            Port = serialPort;
        }
        public void InitializePort(string portName)
        {
            Port.PortName = portName;
            Port.Open();
        }

        public void RenamePort(string name)
        {
            Port.PortName = name;
        }

        public void Write(Packet packet)
        {
            if (Port.IsOpen)
            {
                var buf = new[] { packet.Serialize() };
                Port.Write(buf, 0, 1);
                return;
            }

            Debug.LogWarning($"send data fail. data: {Convert.ToString(packet.Serialize(), 2)}\n" +
                             "port not opened");
        }

        private SerialPort Port { get; set; }

        public void Dispose()
        {
            Port?.Dispose();
        }
    }
}