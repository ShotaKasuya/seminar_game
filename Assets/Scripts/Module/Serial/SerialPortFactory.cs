using System.IO.Ports;

namespace Module.Serial
{
    public class SerialPortFactory<T>
        where T : IPortWritable, new()
    {
        /// <summary>
        /// シリアルポートのインスタンスを作成する
        /// </summary>
        /// <param name="portName"></param>
        /// <returns></returns>
        public T MakeSerial(string portName)
        {
            var t = new T();

            if (t is IPortInitializable portInitializable)
            {
                var serial = new SerialPort()
                {
                    BaudRate = BaudRate,
                    DataBits = PortDataBits,
                    StopBits = StopBits,
                    Parity = PortParity,
                    Handshake = PortHandshake,
                    DtrEnable = DtrEnable,
                    RtsEnable = RtsEnable,
                    PortName = portName,
                    ReadTimeout = ReadTimeOut,
                    WriteTimeout = WriteTimeOut
                };
                portInitializable.InitializePort(serial);
            }

            return t;
        }

        private const int BaudRate = 9600;
        private const int PortDataBits = 8;
        private const StopBits StopBits = System.IO.Ports.StopBits.One;
        private const Parity PortParity = Parity.None;
        private const Handshake PortHandshake = Handshake.None;
        private const bool DtrEnable = true;
        private const bool RtsEnable = false;
        private const int ReadTimeOut = 10000;
        private const int WriteTimeOut = 10000;

    }
}