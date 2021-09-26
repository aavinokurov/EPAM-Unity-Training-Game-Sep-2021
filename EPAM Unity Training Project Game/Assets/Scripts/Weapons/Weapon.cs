using EPAMUnityTraining.Services;
using EPAMUnityTraining.Services.Interfaces;
using EPAMUnityTraining.Weapons.Bullets;
using UnityEngine;
using System.Collections;

namespace EPAMUnityTraining.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public bool isReloading;
        [SerializeField] protected Bullet bullet;
        [SerializeField] protected Transform firePoint;
        [SerializeField] protected float reloadTime = 5f;
        [SerializeField] protected int maxAmmo = 10;

        protected IObjectPoolerService objectPoolerService;
        protected int currentAmmo = 0;

        protected void Awake()
        {
            objectPoolerService = ServiceLocator.Current.Get<IObjectPoolerService>();
            objectPoolerService.AddToPool(bullet, currentAmmo);

            bullet.direction = firePoint;
            currentAmmo = maxAmmo;
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
