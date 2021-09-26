using System.Collections.Generic;
using UnityEngine;

namespace Madasski.Core
{
    public class ObjectPool : MonoBehaviour
    {
        public static Dictionary<MonoBehaviour, Queue<GameObject>> _pools = new Dictionary<MonoBehaviour, Queue<GameObject>>();

        private static ObjectPool _instance;

        public static ObjectPool Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<ObjectPool>();

                    if (_instance == null)
                    {
                        Debug.LogError("There is no instance of ObjectPool in the scene... creating new");
                        var objectPool = new GameObject();
                        _instance = objectPool.AddComponent<ObjectPool>();
                        objectPool.name = "ObjectPool";
                    }
                }

                return _instance;
            }
        }

        // public void AddObjectToPool<T>(T gameObject) where T: MonoBehaviour
        public void AddObjectToPool(MonoBehaviour gameObject)
        {
            if (_pools.ContainsKey(gameObject)) return;

            Queue<GameObject> objectsQueue = new Queue<GameObject>();
            var poolGameObject = new GameObject(gameObject.name + " pool");
            poolGameObject.transform.parent = _instance.transform;

            for (int i = 0; i < 4; i++)
            {
                var obj = Instantiate(gameObject).gameObject;
                obj.SetActive(false);
                obj.transform.parent = poolGameObject.transform;
                objectsQueue.Enqueue(obj);
            }

            _pools.Add(gameObject, objectsQueue);
        }

        public T GetObject<T>(T gameObjectToGet) where T : MonoBehaviour
        {
            if (_pools.ContainsKey(gameObjectToGet))
            {
                if (_pools[gameObjectToGet].Count > 0)
                {
                    var obj = _pools[gameObjectToGet].Dequeue().GetComponent<T>();
                    obj.gameObject.SetActive(true);
                    return obj;
                }
                else
                {
                    //todo: instantiate objects in pool then return one
                    return null;
                }
            }
            else
            {
                //todo: instantiate objects in pool then return one
                return null;
            }
        }
    }
}