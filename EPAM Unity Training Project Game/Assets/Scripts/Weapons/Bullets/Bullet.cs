using EPAMUnityTraining.Interfaces;
using UnityEngine;

namespace EPAMUnityTraining.Weapons.Bullets
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Bullet : Pool, IPooledObject
    {
        [SerializeField] protected int damage;
        [SerializeField] protected float force;
        public Transform direction;

        protected Rigidbody rb;

        protected void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public abstract void OnObjectSpawn();

        protected void OnCollisionEnter(Collision collision)
        {
            Destroy();
        }

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
