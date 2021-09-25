using EPAMUnityTraining.Services;
using EPAMUnityTraining.Services.Interfaces;
using EPAMUnityTraining.Weapons.Bullets;
using UnityEngine;
using System.Collections;

namespace EPAMUnityTraining.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public Bullet bullet;
        public Transform firePoint;
        public int maxAmmo = 10;
        public float reloadTime = 5f;
        public bool isReloading;

        protected IObjectPoolerService objectPoolerService;
        protected int currentAmmo = 0;

        protected void Awake()
        {
            objectPoolerService = ServiceLocator.Current.Get<IObjectPoolerService>();
            bullet.direction = firePoint;
            if (currentAmmo == 0)
            {
                currentAmmo = maxAmmo;
            }
            objectPoolerService.AddToPool(bullet, currentAmmo);
        }

        public abstract void Shoot();
        protected IEnumerator Reload()
        {
            isReloading = true;
            yield return new WaitForSeconds(reloadTime);

            currentAmmo = maxAmmo;
            isReloading = false;
        }

        protected void OnEnable()
        {
            isReloading = false;
        }
    }
}
