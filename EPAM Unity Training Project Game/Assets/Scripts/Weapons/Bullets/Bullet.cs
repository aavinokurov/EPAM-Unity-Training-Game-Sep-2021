using EPAMUnityTraining.Interfaces;
using UnityEngine;

namespace EPAMUnityTraining.Weapons.Bullets
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Bullet : Pool, IPooledObject
    {
        public int damage;
        public float force;
        public Transform direction;

        protected Rigidbody rb;

        protected void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public abstract void OnObjectSpawn();

        protected void OnEnable()
        {
            Invoke("Destroy", 2f);
        }

        protected void Destroy()
        {
            gameObject.SetActive(false);
        }
    }
}
