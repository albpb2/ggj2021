using Pause;
using UnityEngine;

namespace Enemies
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] private Transform _shootingPoint;
        [SerializeField] private LayerMask _playerLayer;
        [SerializeField] private float _range;
        [SerializeField] private float _playerCheckFrequencySeconds;
        [SerializeField] private ProjectilePool _projectilePool;

        private PauseManager _pauseManager;

        private Vector2 _shootingPointPosition;
        private float _lastCheckTime;

        private void Start()
        {
            _pauseManager = FindObjectOfType<PauseManager>();
            _shootingPointPosition = _shootingPoint.position;
        }

        public void Update()
        {
            if (_pauseManager.IsPaused())
                return;

            if (Time.time - _lastCheckTime >= _playerCheckFrequencySeconds)
            {
                if (IsPlayerVisible())
                {
                    Shoot();
                }

                _lastCheckTime = Time.time;
            }
        }

        private bool IsPlayerVisible()
        {
            var hit = Physics2D.Raycast(_shootingPointPosition, Vector2.right, _range, _playerLayer);
            return hit.collider != null;
        }

        private void Shoot()
        {
            var projectile = _projectilePool.GetNextItem();
            projectile.Shoot(_shootingPoint.position, Vector2.right);
        }
    }
}