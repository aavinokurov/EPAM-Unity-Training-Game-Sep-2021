using EPAMUnityTraining.Services;
using EPAMUnityTraining.Services.Interfaces;
using EPAMUnityTraining.Weapons;
using UnityEngine;

namespace EPAMUnityTraining
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    public class Warrior : MonoBehaviour
    {
        public Camera mainCamera;
        [Range(0, 10)] public float speed = 5f;
        public Weapon[] weapons;

        private IInputService inputService;
        private IMovementService movementService;
        private IAnimationService animationService;

        private Rigidbody warriorRigidbody;
        private Animator warriorAnimator;

        private const string RunNameAnimation = "isRun";
        private const string ShootNameAnimation = "isShoot";
        private const string ReloadNameAnimation = "IsReloading";

        private Vector3 movement;
        private float angel;
        private int indexWeapon = 0;

        private void Awake()
        {
            warriorRigidbody = GetComponent<Rigidbody>();
            warriorAnimator = GetComponent<Animator>();

            inputService = ServiceLocator.Current.Get<IInputService>();
            movementService = ServiceLocator.Current.Get<IMovementService>();
            animationService = ServiceLocator.Current.Get<IAnimationService>();
        }

        private void Update()
        {
            movement = inputService.GetHeroesMovementDirection();
            angel = inputService.GetRotationAngleOfHero(mainCamera, transform);

            animationService.SetBool(warriorAnimator, RunNameAnimation, movement != Vector3.zero);
            Shoot();
        }

        private void FixedUpdate()
        {
            movementService.MoveObject(warriorRigidbody, movement, angel, speed);
        }

        private void Shoot()
        {
            if (inputService.GetKeyEDown() && indexWeapon < weapons.Length)
            {
                indexWeapon++;
            }

            if (inputService.GetKeyQDown() && indexWeapon > 0)
            {
                indexWeapon--;
            }
            var weapon = weapons[indexWeapon];
            var isShoot = !weapon.isReloading && inputService.GetFireButtonDown();
            animationService.SetBool(warriorAnimator, ShootNameAnimation, isShoot);
            if (isShoot)
                weapon.Shoot();
            animationService.SetBool(warriorAnimator, ReloadNameAnimation, weapon.isReloading);
        }
    }
}
