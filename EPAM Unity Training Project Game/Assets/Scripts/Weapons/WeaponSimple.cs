namespace EPAMUnityTraining.Weapons
{
    public class WeaponSimple : Weapon
    {
        public override void Shoot()
        {
            if (isReloading)
            {
                return;
            }

            currentAmmo--;
            objectPoolerService.SpawnFromPool(bullet.poolTag, firePoint.position, firePoint.rotation);

            if (currentAmmo <= 0)
            {
                StartCoroutine(Reload());
            }
        }
    }
}
