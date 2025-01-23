using System;
using System.Collections.Generic;
using UnityEngine;

namespace Locator
{
    public static class Locator
    {
        private static Dictionary<Type, object> InstanceDictionary { get; } = new Dictionary<Type, object>();

        public static void Register<T>(T instance) where T : class
        {
            if (InstanceDictionary.ContainsKey(typeof(T)))
            {
                Debug.LogError($"Instance already registered {typeof(T)}");
            }

            InstanceDictionary[typeof(T)] = instance;
        }

        public static bool TryResolve<T>(out T instance) where T : class
        {
            if (InstanceDictionary.TryGetValue(typeof(T), out var value))
            {
                instance = (T)value;
                return true;
            }

            instance = null;
            return false;
        }

        public static T Resolve<T>()
        {
            return (T)InstanceDictionary[typeof(T)];
        }
    }
}