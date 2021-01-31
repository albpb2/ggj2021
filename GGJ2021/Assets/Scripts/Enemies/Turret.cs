using Pause;
using UnityEngine;
using Random = System.Random;

namespace Enemies
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] private Transform _shootingPoint;
        [SerializeField] private LayerMask _playerLayer;
        [SerializeField] private float _range;
        [SerializeField] private float _minPlayerCheckFrequencySeconds;
        [SerializeField] private float _maxPlayerCheckFrequencySeconds;
        [SerializeField] private ProjectilePool _projectilePool;

        private PauseManager _pauseManager;
        private Random _random;

        private Animator _animator;

        private Vector2 _shootingPointPosition;
        private float _lastCheckTime;
        private bool _playerWasVisible;
        private float _nextPlayerCheck;

        private void Start()
        {
            _pauseManager = FindObjectOfType<PauseManager>();
            _random = new Random();

            _animator = GetComponent<Animator>();
            
            _shootingPointPosition = _shootingPoint.position;
            _nextPlayerCheck = _maxPlayerCheckFrequencySeconds;
        }

        public void Update()
        {
            if (_pauseManager.IsPaused())
                return;

            if (Time.time - _lastCheckTime >= _nextPlayerCheck)
            {
                var playerIsVisible = IsPlayerVisible();
                if (playerIsVisible)
                    Shoot();
                
                UpdateAnimation(playerIsVisible);

                _lastCheckTime = Time.time;

                _nextPlayerCheck = _minPlayerCheckFrequencySeconds +
                                   (float)_random.NextDouble() *
                                    (_maxPlayerCheckFrequencySeconds - _minPlayerCheckFrequencySeconds);
            }
        }

        private bool IsPlayerVisible()
        {
            var hit = Physics2D.Raycast(_shootingPointPosition, transform.right, _range, _playerLayer);
            return hit.collider != null;
        }

        private void UpdateAnimation(bool playerIsVisible)
        {
            const string animationCondition = "PlayerIsVisible";
            if (playerIsVisible && !_playerWasVisible)
                _animator.SetBool(animationCondition, true);
            else if (!playerIsVisible && _playerWasVisible)
                _animator.SetBool(animationCondition, false);
            _playerWasVisible = playerIsVisible;
        }

        private void Shoot()
        {
            var projectile = _projectilePool.GetNextItem();
            const string animationTrigger = "Shoot";
            _animator.SetTrigger(animationTrigger);
            projectile.Shoot(_shootingPoint.position, transform.right);
        }
    }
}