using UnityEngine;

namespace EPAMUnityTraining.Weapons.Bullets
{
    public class BulletSimple : Bullet
    {
        public override void OnObjectSpawn()
        {
            rb.AddForce(direction.up * force, ForceMode.Impulse);
        }
    }
}
