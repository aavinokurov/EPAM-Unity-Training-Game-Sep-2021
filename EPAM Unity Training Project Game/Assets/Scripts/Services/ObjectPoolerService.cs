using EPAMUnityTraining.Interfaces;
using EPAMUnityTraining.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EPAMUnityTraining.Services
{
    public class ObjectPoolerService : MonoBehaviour, IObjectPoolerService
    {
        private readonly Dictionary<string, List<GameObject>> _poolDictionary = new Dictionary<string, List<GameObject>>();

        public void AddToPool(Pool pool, int size)
        {
            var objectPool = new List<GameObject>();

            for (int i = 0; i < size; i++)
            {
                var poolObject = Instantiate(pool.prefab);
                poolObject.SetActive(false);
                objectPool.Add(poolObject);
            }

            if (!_poolDictionary.ContainsKey(pool.poolTag))
            {
                _poolDictionary.Add(pool.poolTag, objectPool);
                return;
            }
            _poolDictionary[pool.poolTag] = objectPool;
        }

        public void SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
        {
            if (!_poolDictionary.TryGetValue(tag, out var objects))
            {
                Debug.Log($"Pool with tag: {tag} doesn't excist.");
                return;
            }

            var objectToSpawn = objects.FirstOrDefault(o => !o.activeInHierarchy);
            if (objectToSpawn == null)
            {
                return;
            }

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            objectToSpawn.GetComponent<IPooledObject>()?.OnObjectSpawn();
        }
    }
}
