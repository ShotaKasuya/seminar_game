using Domain.IModel.OutGame.SelectSerial;
using UnityEngine;

namespace Model.OutGame.SelectSerial
{
    public class SelectedSerialModel: IMutSelectedSerialModel
    {
        public string SelectedPortName { get; private set; }
        public void SetSerialPort(string portName)
        {
            Debug.Log($"on set serial port name: {portName}");
            SelectedPortName = portName;
        }
    }
}