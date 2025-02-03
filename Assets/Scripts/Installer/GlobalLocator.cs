using System;
using System.Collections.Generic;
using Module.Installer;
using Module.Serial;
using Module.Singleton;
using UnityEngine;

namespace Installer
{
    public class GlobalLocator : SingletonMonoBehaviour<GlobalLocator>, IDisposable
    {
        [SerializeField] private bool useDebugSerial;

        protected override void Awake()
        {
            base.Awake();

            if (useDebugSerial)
            {
                var moqSerial = new MoqSerialPort();
                Register<IPortWritable>(moqSerial);
                Register<IPortInitializable>(moqSerial);
            }
            else
            {
                var serialPort = SerialPortFactory.MakeSerial();

                var portManager = new SerialPortManager(serialPort);
                Register<IPortWritable>(portManager);
                Register<IPortInitializable>(portManager);
            }
        }

        private Dictionary<Type, object> InstanceDictionary { get; } = new Dictionary<Type, object>();
        private HashSet<ITickable> Tickables { get; } = new();
        private HashSet<IDisposable> Disposables { get; } = new();

        private void Update()
        {
            foreach (var tickable in Tickables)
            {
                tickable.Tick();
            }
        }

        private void Register<T>(T instance) where T : class
        {
            InstanceDictionary[typeof(T)] = instance;
            if (instance is IDisposable disposable)
            {
                Disposables.Add(disposable);
            }

            if (instance is ITickable tickable)
            {
                Tickables.Add(tickable);
            }
        }

        public T Resolve<T>() where T : class
        {
            if (InstanceDictionary.TryGetValue(typeof(T), out var instance))
            {
                return instance as T;
            }

            Debug.LogWarning($"Locator: {typeof(T).Name} not found");
            return null;
        }

        public void Dispose()
        {
            foreach (var disposable in Disposables)
            {
                disposable.Dispose();
            }
        }
    }
}