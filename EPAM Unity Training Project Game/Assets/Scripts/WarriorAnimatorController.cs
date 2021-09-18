using UnityEngine;

namespace EPAMUnityTraining
{
    public class WarriorAnimatorController : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void Run(bool condition)
        {
            animator.SetBool("isRun", condition);
        }

        public void Shoot(bool condition)
        {
            animator.SetBool("isShoot", condition);
        }
    }
}
