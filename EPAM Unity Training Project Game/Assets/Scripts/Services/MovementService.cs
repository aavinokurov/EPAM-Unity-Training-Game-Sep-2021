using EPAMUnityTraining.Services.Interfaces;
using UnityEngine;

namespace EPAMUnityTraining.Services
{
    public class MovementService : IMovementService
    {
        public void MoveObject(Rigidbody objectRigidbody, Vector3 movement, float angle, float speed)
        {
            objectRigidbody.MovePosition(objectRigidbody.position + movement * speed * Time.fixedDeltaTime);
            objectRigidbody.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        }

        public Vector3 FollowForTarget(Vector3 target, Vector3 currentPosition, float smoothSpeed, Vector3 offset)
        {
            var desiredPosition = target + offset;
            var smoothedPosition = Vector3.Lerp(currentPosition, desiredPosition, smoothSpeed);
            return smoothedPosition;
        }
    }
}
