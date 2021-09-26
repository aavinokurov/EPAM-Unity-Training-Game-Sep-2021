using EPAMUnityTraining.Enemies;
using EPAMUnityTraining.Services;
using EPAMUnityTraining.Services.Interfaces;
using UnityEngine;

namespace EPAMUnityTraining
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Transform player;

        [SerializeField] private Enemy[] enemies;

        [SerializeField] private Vector3 lowerLeftCornerAreaToSpawn;
        [SerializeField] private Vector3 topRightCornerAreaToSpawn;

        private IObjectPoolerService objectPoolerService;

        private void Awake()
        {
            objectPoolerService = ServiceLocator.Current.Get<IObjectPoolerService>();

            foreach (var enemy in enemies)
            {
                enemy.player = player;
                objectPoolerService.AddToPool(enemy, enemy.maxSizeSpawn);
            }
        }

        private void Update()
        {
            foreach (var enemy in enemies)
            {
                if (!enemy.isSpawn)
                {
                    continue;
                }

                objectPoolerService.SpawnFromPool(enemy.poolTag, GetRandomPosition(), Quaternion.identity);
                StartCoroutine(enemy.WaitSpawn());
            }
        }

        private Vector3 GetRandomPosition()
        {
            var x = Random.Range(lowerLeftCornerAreaToSpawn.x, topRightCornerAreaToSpawn.x);
            var y = 0f;
            var z = Random.Range(lowerLeftCornerAreaToSpawn.z, topRightCornerAreaToSpawn.z);
            var res = new Vector3(-x, y, z);
            return res;
        }
    }
}
