using UnityEngine;

namespace Enemies
{
    public class Destructible : MonoBehaviour
    {
        [SerializeField] private int _healthPoints;
        [SerializeField] private bool _shouldExplode;

        private ExplosionPool _explosionPool;

        private void Start()
        {
            _explosionPool = FindObjectOfType<ExplosionPool>();
        }

        public void Damage(int damagePoints)
        {
            _healthPoints -= damagePoints;
            if (_healthPoints <= 0)
            {
                if (_shouldExplode)
                    Explode();
                Destroy(gameObject);
            }
        }

        private void Explode()
        {
            var explosion = _explosionPool.GetNextItem();
            explosion.SetPosition(transform.position);
            explosion.Enable();
        }
    }
}