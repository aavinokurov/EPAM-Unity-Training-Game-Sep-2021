using UnityEngine;

namespace EPAMUnityTraining.Services.Interfaces
{
    public interface IMovementService
    {
        void MoveObject(Rigidbody objectRigidbody, Vector3 movement, float angle, float speed);
        Vector3 FollowForTarget(Vector3 target, Vector3 currentPosition, float smoothSpeed, Vector3 offset);
    }
}
