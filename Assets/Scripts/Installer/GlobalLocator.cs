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
        protected override void Awake()
        {
            base.Awake();

            var serialPort = SerialPortFactory.MakeSerial();

            var portManager = new SerialPortManager(serialPort);
            Register<IPortWritable>(portManager);
            Register<IPortInitializable>(portManager);

            var serialLogger = new SerialLogger(serialPort);
            Register(serialLogger);
        }

        private static Dictionary<Type, object> InstanceDictionary { get; } = new Dictionary<Type, object>();
        private static HashSet<ITickable> Tickables { get; } = new();
        private static HashSet<IDisposable> Disposables { get; } = new();

        private void Update()
        {
            foreach (var tickable in Tickables)
            {
                tickable.Tick();
            }
        }

        private static void Register<T>(T instance) where T : class
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

        public static T Resolve<T>() where T : class
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