using UnityEngine;

namespace Module.Serial
{
    public class MoqSerialPort: IPortWritable
    {
        public void RenamePort(string name)
        {
            Debug.Log($"name changed from {_name} to {name}");
            _name = name;
        }

        public void Write(Packet packet)
        {
            Debug.Log($"Finger {packet.ToString()} shocked!");
        }

        private string _name;
    }
}