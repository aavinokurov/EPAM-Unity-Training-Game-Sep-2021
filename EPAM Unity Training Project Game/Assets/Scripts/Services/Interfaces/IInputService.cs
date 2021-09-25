using UnityEngine;

namespace EPAMUnityTraining.Services.Interfaces
{
    public interface IInputService
    {
        Vector3 GetHeroesMovementDirection();
        float GetRotationAngleOfHero(Camera camera, Transform heroesTransform);
        bool GetFireButtonDown();
        bool GetKeyEDown();
        public bool GetKeyQDown();
    }
}
