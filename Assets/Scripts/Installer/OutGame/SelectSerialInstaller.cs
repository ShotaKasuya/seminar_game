using Domain.UseCase.OutGame.SelectSerialPort;
using Module.Serial;
using UnityEngine;
using View.OutGame;

namespace Installer.OutGame
{
    public class SelectSerialInstaller : MonoBehaviour
    {
        [SerializeField] private SelectionView selectionView;

        private SetSerialPortCase<SerialPortManager> _serialPortCase;

        private void Awake()
        {
            var portFactory = new SerialPortFactory<SerialPortManager>();
            _serialPortCase = new SetSerialPortCase<SerialPortManager>(portFactory, selectionView);
        }

        private void OnDestroy()
        {
            _serialPortCase.Dispose();
        }
    }
}