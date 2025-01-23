using System;
using Domain.IView.OutGame.SelectSerialPort;
using Module.Serial;

namespace Domain.UseCase.OutGame.SelectSerialPort
{
    public class SetSerialPortCase<T> : IDisposable
    where T: class, IPortWritable, new()
    {
        public SetSerialPortCase
        (
            SerialPortFactory<T> portFactory,
            ISelectionView selectionView
        )
        {
            PortFactory = portFactory;
            SelectionView = selectionView;

            selectionView.UpdateList(PortUtil.GetSerialPorts());
            selectionView.SelectEvent += OnSelect;
        }

        private void OnSelect(SelectedSerial serial)
        {
            if (Locator.Locator.TryResolve(out T instance))
            {
                instance.RenamePort(serial.SerialName);
                return;
            }
            IPortWritable serialPort = PortFactory.MakeSerial(serial.SerialName);
            Locator.Locator.Register(serialPort);
        }
        
        private SerialPortFactory<T> PortFactory { get; }
        private ISelectionView SelectionView { get; }

        public void Dispose()
        {
            SelectionView.SelectEvent -= OnSelect;
        }
    }
}