using EPAMUnityTraining.Services.Interfaces;
using UnityEngine;

namespace EPAMUnityTraining.Services
{
    public class InputService : IInputService
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";
        private const string Fire = "Fire1";

        public Vector3 GetHeroesMovementDirection()
        {
            var movement = new Vector3();
            movement.x = Input.GetAxis(HorizontalAxis);
            movement.z = Input.GetAxis(VerticalAxis);

            return movement;
        }

        public float GetRotationAngleOfHero(Camera camera, Transform heroesTransform)
        {
            var positionOnScreen = camera.WorldToViewportPoint(heroesTransform.position);
            var mousePos = (Vector2)camera.ScreenToViewportPoint(Input.mousePosition);
            var angle = Mathf.Atan2(mousePos.x - positionOnScreen.x, mousePos.y - positionOnScreen.y) *
               Mathf.Rad2Deg;

            return angle;
        }

        public bool GetFireButtonDown()
        {
            return Input.GetButtonDown(Fire);
        }

        public bool GetKeyEDown()
        {
            return Input.GetKeyDown(KeyCode.E);
        }

        public bool GetKeyQDown()
        {
            return Input.GetKeyDown(KeyCode.Q);
        }
    }
}
