using UnityEngine;

namespace EPAMUnityTraining
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        [Range(0, 1)] public float smoothSpeed = 0.125f;
        public Vector3 offset;

        private void FixedUpdate()
        {
            var desiredPosition = target.position + offset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
