using System.IO.Ports;

namespace Module.Serial
{
    public class SerialPortFactory
    {
        /// <summary>
        /// シリアルポートのインスタンスを作成する
        /// </summary>
        public static SerialPort MakeSerial()
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
                    ReadTimeout = ReadTimeOut,
                    WriteTimeout = WriteTimeOut
                };

            return serial;
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