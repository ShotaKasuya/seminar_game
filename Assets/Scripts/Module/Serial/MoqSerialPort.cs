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

        public void Write(Finger finger)
        {
            Debug.Log($"Finger {finger} shocked!");
        }

        private string _name;
    }
}