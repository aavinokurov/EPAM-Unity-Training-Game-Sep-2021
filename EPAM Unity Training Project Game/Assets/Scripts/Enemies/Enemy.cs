using System.Collections;
using EPAMUnityTraining.Services;
using EPAMUnityTraining.Services.Interfaces;
using EPAMUnityTraining.Weapons;
using UnityEngine;

namespace EPAMUnityTraining.Enemies
{
    public class Enemy : Pool
    {
        public Transform player;

        [Range(0,5)]
        [SerializeField]
        private float moveSpeed = 1f;

        [SerializeField] private string nameAnimationRun;
        [SerializeField] private Animator animator;

        [SerializeField] private Weapon weapon;

        public bool isSpawn;
        public int maxSizeSpawn = 5;
        [SerializeField] private float timeToSpawn = 1f;

        private IMovementService movementService;
        private IAnimationService animationService;

        private Rigidbody rb;
        private Vector3 movement;

        private void Awake()
        {
            isSpawn = true;
            rb = this.GetComponent<Rigidbody>();

            movementService = ServiceLocator.Current.Get<IMovementService>();
            animationService = ServiceLocator.Current.Get<IAnimationService>();
        }

        private void Update()
        {
            movement = (player.position - transform.position);
            movement.Normalize();

            if (!string.IsNullOrEmpty(nameAnimationRun))
            {
                animationService.SetBool(animator, nameAnimationRun, true);
            }

            weapon?.Shoot();
        }

        private void FixedUpdate()
        {
            movementService.MoveObject(rb, movement, 0, moveSpeed);
            transform.LookAt(player);
        }

        public IEnumerator WaitSpawn()
        {
            isSpawn = false;
            yield return new WaitForSeconds(timeToSpawn);
            isSpawn = true;
        }
    }
}