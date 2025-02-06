using Domain.UseCase.OutGame.SelectSerialPort;
using Model.OutGame.SelectSerial;
using Module.Serial;
using UnityEngine;
using View.OutGame;

namespace Installer.OutGame
{
    public class SelectSerialInstaller : MonoBehaviour
    {
        [SerializeField] private SelectionView selectionView;

        private SetSerialPortCase _serialPortCase;

        private void Start()
        {
            var portInitializable = GlobalLocator.Instance.Resolve<IPortInitializable>();
            var serialModel = new SelectedSerialModel();
            _serialPortCase = new SetSerialPortCase(portInitializable, selectionView, serialModel);
        }

        private void OnDestroy()
        {
            _serialPortCase?.Dispose();
        }
    }
}