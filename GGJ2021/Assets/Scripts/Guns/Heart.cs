using System;
using System.Collections;
using UnityEngine;
using Random = System.Random;

namespace Guns
{
    public class Heart : MonoBehaviour
    {
        [SerializeField] private AnimationClip[] _leftAnimations;
        [SerializeField] private AnimationClip[] _rightAnimations;
        
        private Random _random;
        
        private Rigidbody2D _rigidbody;
        private Animator _animator;

        private bool _movingRight;

        private void Awake()
        {
            _random = new Random();
            
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            StartNextAnimation();
        }

        public void StartNextAnimation()
        {
            var sourceAnimations = _movingRight ? _rightAnimations : _leftAnimations;
            var animation = SelectAnimation(sourceAnimations);
            Debug.Log($"Gonna play {animation.name}");
            _animator.SetTrigger($"Play{animation.name}");
            _movingRight = !_movingRight;
        }

        private AnimationClip SelectAnimation(AnimationClip[] animations)
        {
            var animationIndex = _random.Next(0, animations.Length);
            return animations[animationIndex];
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(Tags.Ground))
            {
                StartNextAnimation();
            }
        }
    }
}