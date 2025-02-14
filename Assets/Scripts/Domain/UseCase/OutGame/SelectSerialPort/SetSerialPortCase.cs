using System;
using Domain.IModel.OutGame.SelectSerial;
using Domain.IView.OutGame.SelectSerialPort;
using Module.Serial;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Domain.UseCase.OutGame.SelectSerialPort
{
    public class SetSerialPortCase : IDisposable
    {
        public SetSerialPortCase
        (
            IPortInitializable portInitializable,
            ISelectionView selectionView,
            IMutSelectedSerialModel serialModel
        )
        {
            PortInitializable = portInitializable;
            SelectionView = selectionView;
            SerialModel = serialModel;

            selectionView.SelectEvent += OnSelect;
            selectionView.DecisionEvent += OnDecision;
            selectionView.UpdateList(PortUtil.GetSerialPorts());
        }

        private void OnDecision()
        {
            var serialName = SerialModel.SelectedPortName;
            Debug.Log(serialName);
            PortInitializable.InitializePort(serialName);
            SceneManager.LoadScene("SAHATestScene");
        }

        private void OnSelect(SelectedSerial serial)
        {
            SerialModel.SetSerialPort(serial.SerialName);
        }
        
        private IMutSelectedSerialModel SerialModel { get; }
        private IPortInitializable PortInitializable { get; }
        private ISelectionView SelectionView { get; }

        public void Dispose()
        {
            SelectionView.SelectEvent -= OnSelect;
        }
    }
}