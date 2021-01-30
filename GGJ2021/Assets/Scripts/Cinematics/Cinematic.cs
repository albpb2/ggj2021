using UnityEngine;

namespace Cinematics
{
    public abstract class Cinematic : MonoBehaviour
    {
        public abstract void Play();
        public abstract bool IsFinished();
    }
}