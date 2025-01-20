using System.IO.Ports;
using Module.Serial;

public class SerialPortManager
{
    public static SerialPortManager Instance { get; private set; }

    public void Init(
        string portName,
        SerialPortToml toml
    )
    {
        Instance = new SerialPortManager(portName, toml);
    }
    private SerialPortManager
    (
        string portName,
        SerialPortToml portToml
    )
    {
        Port = new SerialPort();

        Port.PortName = portName;
        Port.BaudRate = portToml.BaudRate;
        Port.Parity = portToml.PortParity;
        Port.DataBits = portToml.PortDataBits;
        Port.StopBits = portToml.StopBits;
        Port.Handshake = portToml.PortHandshake;
        Port.DtrEnable = true;  // Arduinoの場合必要 https://qiita.com/GANTZ/items/da08d09d318d59a60224

        Port.ReadTimeout = portToml.ReadTimeOut;
        Port.WriteTimeout = portToml.WriteTimeOut;
    }

    private SerialPort Port { get; }
}