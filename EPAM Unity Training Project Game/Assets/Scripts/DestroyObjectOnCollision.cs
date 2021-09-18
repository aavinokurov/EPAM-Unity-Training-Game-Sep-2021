using UnityEngine;

namespace Assets.Scripts
{
    public class DestroyObjectOnCollision : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }
    }
}
