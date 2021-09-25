using UnityEngine;

namespace EPAMUnityTraining.Services.Interfaces
{
    public interface IObjectPoolerService
    {
        void AddToPool(Pool pool, int size);
        void SpawnFromPool(string tag, Vector3 position, Quaternion rotation);
    }
}
