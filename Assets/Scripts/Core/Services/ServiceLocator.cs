using System.Collections.Generic;
using UnityEngine;

namespace Core.Services
{
    public class ServiceLocator : MonoBehaviour, IServiceLocator
    {
        private static List<IService> s_services;
        private static ServiceLocator s_instance;

        public static ServiceLocator Instance
        {
            get
            {
                if (s_instance == null)
                {
                    s_instance = FindObjectOfType<ServiceLocator>();

                    if (s_instance == null)
                    {
                        Debug.Log("There is no instance of ServiceLocator in the scene... creating new");
                        s_services = new List<IService>();
                        var serviceLocatorGO = new GameObject();
                        s_instance = serviceLocatorGO.AddComponent<ServiceLocator>();
                        serviceLocatorGO.name = "ServiceLocator";
                    }
                }

                return s_instance;
            }
        }

        public void Register<T>(T service) where T : IService
        {
            if (s_services.Contains(service)) return;

            s_services.Add(service);
        }

        public T Get<T>() where T : IService
        {
            var res = s_services.Find(x => x is T);
            return (T) res;
        }
    }
}