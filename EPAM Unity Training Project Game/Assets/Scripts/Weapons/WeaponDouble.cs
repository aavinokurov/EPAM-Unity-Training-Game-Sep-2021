namespace EPAMUnityTraining.Weapons
{
    public class WeaponDouble : Weapon
    {
        public override void Shoot()
        {
            if (isReloading)
            {
                return;
            }

            currentAmmo -= 2;
            objectPoolerService.SpawnFromPool(bullet.poolTag, firePoint.position + (firePoint.forward * 0.5f), firePoint.rotation);
            objectPoolerService.SpawnFromPool(bullet.poolTag, firePoint.position + (firePoint.forward * -0.5f), firePoint.rotation);

            if (currentAmmo <= 0)
            {
                StartCoroutine(Reload());
            }
        }
    }
}
