using System;
using Domain.UseCase.OutGame.SelectSerialPort;
using Module.Serial;
using UnityEngine;
using View.OutGame;

namespace Installer.OutGame
{
    public class SerialTestInstaller: MonoBehaviour, IDisposable
    {
        [SerializeField] private SerialTestView testView;

        private IDisposable _disposable;
        
        private void Awake()
        {
            var port = GlobalLocator.Resolve<IPortWritable>();
            _disposable = new Send2SerialCase(port, testView);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}