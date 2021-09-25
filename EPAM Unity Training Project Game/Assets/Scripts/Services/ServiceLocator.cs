using System;
using System.Collections.Generic;
using UnityEngine;

namespace EPAMUnityTraining.Services
{
    public class ServiceLocator
    {
        private ServiceLocator() { }

        private readonly Dictionary<string, object> _services = new Dictionary<string, object>();

        public static ServiceLocator Current { get; private set; }

        public static void Initiailze()
        {
            Current = new ServiceLocator();
        }

        public T Get<T>()
        {
            string key = typeof(T).Name;
            if (!_services.ContainsKey(key))
            {
                Debug.LogError($"{key} not registered with {GetType().Name}");
                throw new InvalidOperationException();
            }

            return (T)_services[key];
        }

        public void Register<T>(T service)
        {
            string key = typeof(T).Name;
            if (_services.ContainsKey(key))
            {
                Debug.LogError($"Attempted to register service of type {key} which is already registered with the {GetType().Name}.");
                return;
            }

            _services.Add(key, service);
        }
    }
}