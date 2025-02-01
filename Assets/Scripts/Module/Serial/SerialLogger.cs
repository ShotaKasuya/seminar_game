using System;
using System.IO.Ports;
using System.Threading;
using Module.Installer;
using UnityEngine;

namespace Module.Serial
{
    public class SerialLogger : ITickable, IDisposable
    {
        public SerialLogger
        (
            SerialPort serialPort
        )
        {
            SerialPort = serialPort;

            _isRunning = true;
            ReadThread = new Thread(ReadSerialData);
            ReadThread.Start();
        }

        public void Tick()
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
                        // var packetBuff = new byte[2];
                        // var data = SerialPort.Read(packetBuff, 0, 1);
                        // if (data != 0)
                        // {
                        //     var packet = Packet.Deserialize(packetBuff[0]);
                        //     Debug.Log($"packet => {packet.ToString()}");
                        // }

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

        public void Dispose()
        {
            _isRunning = false;
            if (ReadThread is not null && ReadThread.IsAlive)
            {
                ReadThread.Join();
            }
        }
    }
}