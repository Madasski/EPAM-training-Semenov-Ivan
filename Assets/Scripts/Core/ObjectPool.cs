using System.Collections.Generic;
using UnityEngine;

namespace Madasski.Core
{
    public class ObjectPool : MonoBehaviour
    {
        private static Dictionary<GameObject, Queue<GameObject>> _pools;
        private static Dictionary<GameObject, GameObject> _spawnedObjects;

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
                        Debug.Log("There is no instance of ObjectPool in the scene... creating new");
                        _pools=new Dictionary<GameObject, Queue<GameObject>>();
                        _spawnedObjects = new Dictionary<GameObject, GameObject>();
                        var objectPool = new GameObject();
                        _instance = objectPool.AddComponent<ObjectPool>();
                        objectPool.name = "ObjectPool";
                    }
                }

                return _instance;
            }
        }

        public void CreatePool<T>(T prefab) where T : MonoBehaviour => CreatePool(prefab.gameObject);

        public void CreatePool(GameObject gameObject)
        {
            if (gameObject == null || _pools.ContainsKey(gameObject))
            {
                return;
            }

            Queue<GameObject> objectsQueue = new Queue<GameObject>();
            var poolGameObject = new GameObject(gameObject.name + " pool");
            poolGameObject.transform.parent = _instance.transform;

            for (int i = 0; i < 5; i++)
            {
                var obj = Instantiate(gameObject).gameObject;
                obj.SetActive(false);
                obj.transform.parent = poolGameObject.transform;
                objectsQueue.Enqueue(obj);
            }

            _pools.Add(gameObject, objectsQueue);
        }

        public T Spawn<T>(T prefab) where T : MonoBehaviour => Spawn(prefab.gameObject).GetComponent<T>();

        public GameObject Spawn(GameObject prefab)
        {
            if (_pools.ContainsKey(prefab))
            {
                GameObject obj;
                if (_pools[prefab].Count > 0)
                {
                    obj = _pools[prefab].Dequeue();
                    obj.SetActive(true);
                }
                else
                {
                    obj = Instantiate(prefab);
                }

                _spawnedObjects.Add(obj, prefab);
                return obj;
            }
            else
            {
                CreatePool(prefab);
                return Spawn(prefab);
            }
        }

        public void ReturnObjectToPool<T>(T gameObjectToReturn) where T : MonoBehaviour => ReturnObjectToPool(gameObjectToReturn.gameObject);

        public void ReturnObjectToPool(GameObject gameObjectToReturn)
        {
            if (_spawnedObjects.TryGetValue(gameObjectToReturn, out var prefab))
            {
                ReturnObjectToPool(gameObjectToReturn, prefab);
            }
        }

        public void ReturnObjectToPool(GameObject gameObjectToReturn, GameObject prefab)
        {
            _spawnedObjects.Remove(gameObjectToReturn);
            if (gameObjectToReturn == null) return;

            _pools[prefab].Enqueue(gameObjectToReturn);
            gameObjectToReturn.SetActive(false);
        }
    }
}