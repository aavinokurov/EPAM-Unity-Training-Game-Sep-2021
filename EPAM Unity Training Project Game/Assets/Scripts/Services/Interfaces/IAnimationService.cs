using UnityEngine;

namespace EPAMUnityTraining.Services.Interfaces
{
    public interface IAnimationService
    {
        void SetBool(Animator animator, string name, bool condition);
    }
}
