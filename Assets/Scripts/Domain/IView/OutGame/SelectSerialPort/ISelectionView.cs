using System;
using System.Collections.Generic;

namespace Domain.IView.OutGame.SelectSerialPort
{
    public interface ISelectionView
    {
        public Action DecisionEvent { get; set; }
        public Action<SelectedSerial> SelectEvent { get; set; }
        public void UpdateList(List<string> listContents);
    }

    public struct SelectedSerial
    {
        public string SerialName { get; }

        public SelectedSerial(string serialName)
        {
            SerialName = serialName;
        }
    }
}