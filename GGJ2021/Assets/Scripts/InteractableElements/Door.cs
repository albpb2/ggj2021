using UnityEngine;

namespace InteractableElements
{
    public class Door : MonoBehaviour
    {
        private Collider2D _collider;
        private Animator _animator;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _animator = GetComponent<Animator>();
        }

        public void Open()
        {
            _collider.enabled = false;
            const string openAnimationTrigger = "Open";
            _animator.SetTrigger(openAnimationTrigger);
        }
    }
}