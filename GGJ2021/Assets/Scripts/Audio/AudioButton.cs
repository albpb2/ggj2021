using System;
using FMODUnity;
using UnityEngine;

namespace Audio
{
    public class AudioButton : MonoBehaviour
    {
        private StudioEventEmitter _studioEventEmitter;
        
        private bool _playing;

        private void Awake()
        {
            _studioEventEmitter = GetComponent<StudioEventEmitter>();
        }

        public void PlayOrStop()
        {
            if (_playing)
                _studioEventEmitter.Stop();
            else
                _studioEventEmitter.Play();

            _playing = !_playing;
        }
    }
}