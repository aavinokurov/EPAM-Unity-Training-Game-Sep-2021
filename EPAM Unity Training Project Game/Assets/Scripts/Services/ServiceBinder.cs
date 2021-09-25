using EPAMUnityTraining.Services.Interfaces;
using UnityEngine;

namespace EPAMUnityTraining.Services
{
    public static class ServiceBinder
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initiailze()
        {
            ServiceLocator.Initiailze();

            ServiceLocator.Current.Register<IInputService>(new InputService());
            ServiceLocator.Current.Register<IMovementService>(new MovementService());
            ServiceLocator.Current.Register<IAnimationService>(new AnimationService());
            ServiceLocator.Current.Register<IObjectPoolerService>(new ObjectPoolerService());
        }
    }
}
