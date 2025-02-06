using System;
using System.IO.Ports;
using System.Threading;
using Module.Installer;
using UnityEngine;

namespace Module.Serial
{
    public class SerialPortManager : IPortWritable, IPortInitializable, ITickable, IDisposable
    {
        public SerialPortManager(SerialPort serialPort)
        {
            SerialPort = serialPort;
            _isRunning = true;
            ReadThread = new Thread(ReadSerialData);
            ReadThread.Start();
        }

        public void InitializePort(string portName)
        {
            SerialPort.PortName = portName;
            SerialPort.Open();
        }

        public void Tick(float deltaTime)
        {
            if (!string.IsNullOrEmpty(_buf))
            {
                Debug.Log(_buf);
                _buf = "";
            }
        }

        private void ReadSerialData()
        {
            while (_isRunning)
            {
                try
                {
                    if (SerialPort.IsOpen)
                    {
                        var data = SerialPort.ReadLine();
                        if (!string.IsNullOrEmpty(data))
                        {
                            _buf = data;
                        }
                    }
                }
                catch (TimeoutException)
                {
                }
                catch (Exception e)
                {
                    Debug.LogError($"serial port error: {e}");
                }
            }
        }

        private bool _isRunning;
        private string _buf;
        private Thread ReadThread { get; }
        private SerialPort SerialPort { get; }

        public void Write(Packet packet)
        {
            if (SerialPort.IsOpen)
            {
                var buf = new[] { packet.Serialize() };
                SerialPort.Write(buf, 0, 1);
                return;
            }

            Debug.LogWarning($"send data fail. data: {Convert.ToString(packet.Serialize(), 2)}\n" +
                             "port not opened");
        }


        public void Dispose()
        {
            _isRunning = false;
            SerialPort.Close();
            if (ReadThread.IsAlive)
            {
                ReadThread.Join();
            }
            SerialPort.Dispose();
        }
    }
}