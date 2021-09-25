using EPAMUnityTraining.Services.Interfaces;
using UnityEngine;


namespace EPAMUnityTraining.Services
{
    public class AnimationService : IAnimationService
    {
        public void SetBool(Animator animator, string name, bool condition)
        {
            animator.SetBool(name, condition);
        }
    }
}
