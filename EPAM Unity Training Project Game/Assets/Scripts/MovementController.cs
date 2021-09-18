using UnityEngine;

namespace EPAMUnityTraining
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovementController : MonoBehaviour
    {
        [Range(0, 10)] public float speed = 5f;

        [SerializeField] private Rigidbody objectRigidbody;

        public void MoveObject(Vector3 movement, float angle)
        {
            objectRigidbody.MovePosition(objectRigidbody.position + movement * speed * Time.fixedDeltaTime);
            objectRigidbody.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        }
    }
}
