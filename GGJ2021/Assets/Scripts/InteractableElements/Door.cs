using FMODUnity;
using UnityEngine;

namespace InteractableElements
{
    public class Door : MonoBehaviour
    {
        private Collider2D _collider;
        private Animator _animator;
        private StudioEventEmitter _studioEventEmitter;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _animator = GetComponent<Animator>();
            _studioEventEmitter = GetComponent<StudioEventEmitter>();
        }

        public void Open()
        {
            _studioEventEmitter.Play();

            _collider.enabled = false;

            const string openAnimationTrigger = "Open";
            _animator.SetTrigger(openAnimationTrigger);
        }
    }
}