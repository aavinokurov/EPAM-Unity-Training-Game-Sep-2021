using UnityEngine;

namespace EPAMUnityTraining
{
    public class ShootController : MonoBehaviour
    {
        public Transform firePoint;
        public GameObject bulletPrefab;
        [Range(1,20)]public float bulletForce = 20f;

        public void Shoot(bool condition)
        {
            if (condition)
            {
                var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                var bulletRigidBody = bullet.GetComponent<Rigidbody>();
                bulletRigidBody.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);
            }
        }
    }
}
