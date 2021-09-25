using EPAMUnityTraining.Services;
using EPAMUnityTraining.Services.Interfaces;
using UnityEngine;

namespace EPAMUnityTraining
{
    public class MainCamera : MonoBehaviour
    {
        [Range(0, 1)] public float smoothSpeed = 0.125f;
        public Transform target;
        public Vector3 offset;

        private IMovementService movementService;

        private void Awake()
        {
            movementService = ServiceLocator.Current.Get<IMovementService>();
        }

        private void FixedUpdate()
        {
            transform.position = movementService.FollowForTarget(target.position, transform.position, smoothSpeed, offset);
        }
    }
}
