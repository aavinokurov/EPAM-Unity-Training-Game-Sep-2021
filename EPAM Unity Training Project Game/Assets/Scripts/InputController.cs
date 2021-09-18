using UnityEngine;

namespace EPAMUnityTraining
{
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(ShootController))]
    public class InputController : MonoBehaviour
    {
        public Camera mainCamera;

        [SerializeField] private MovementController movementController;
        [SerializeField] private ShootController shootController;
        [SerializeField] private WarriorAnimatorController animator;
        private Vector3 movement;
        private float angle;

        private void Update()
        {
            movement.x = Input.GetAxis(ConstStrings.HorizontalAxis);
            movement.z = Input.GetAxis(ConstStrings.VerticalAxis);

            var positionOnScreen = mainCamera.WorldToViewportPoint(transform.position);
            var mousePos = (Vector2)mainCamera.ScreenToViewportPoint(Input.mousePosition);
            angle = Mathf.Atan2(mousePos.x - positionOnScreen.x, mousePos.y - positionOnScreen.y) * 
                Mathf.Rad2Deg;

            animator.Run(movement != Vector3.zero);

            var isShoot = Input.GetButtonDown(ConstStrings.Fire);
            shootController.Shoot(isShoot);
            animator.Shoot(isShoot);
        }

        private void FixedUpdate()
        {
            movementController.MoveObject(movement, angle);
        }
    }
}
