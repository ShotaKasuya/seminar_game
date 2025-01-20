using System.IO.Ports;
using UnityEngine;

namespace Module.Serial
{
    [CreateAssetMenu(fileName = nameof(SerialPortToml), menuName = "ScriptableObject/SerialPortToml", order = 0)]
    public class SerialPortToml : ScriptableObject
    {
        public int BaudRate => baudRate;
        public Parity PortParity => portParity;
        public int PortDataBits => portDataBits;
        public StopBits StopBits => stopBits;
        public Handshake PortHandshake => portHandshake;
        public int ReadTimeOut => readTimeOut;
        public int WriteTimeOut => writeTimeOut;

        [SerializeField] private int baudRate;
        [SerializeField] private Parity portParity;
        [SerializeField] private int portDataBits;
        [SerializeField] private StopBits stopBits;
        [SerializeField] private Handshake portHandshake;
        [SerializeField] private int readTimeOut;
        [SerializeField] private int writeTimeOut;
    }
}