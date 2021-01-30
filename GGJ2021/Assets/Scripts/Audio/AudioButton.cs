using FMODUnity;
using UnityEngine;

namespace Audio
{
    public class AudioButton : MonoBehaviour
    {
        private StudioEventEmitter _studioEventEmitter;
        
        private bool _playing;

        public void PlayOrStop()
        {
            if (_playing)
                _studioEventEmitter.Stop();
            else
                _studioEventEmitter.Play();
        }
    }
}