using UnityEngine;

namespace Module.Serial
{
    public class MoqSerialPort: IPortInitializable, IPortWritable
    {
        public void Write(Packet packet)
        {
            Debug.Log($"Finger {packet.ToString()} shocked!");
        }
        public void InitializePort(string portName)
        {
            Debug.Log($"port name set => {portName}");
        }
    }
}