using UnityEngine;

namespace Enemies
{
    public class Destructible : MonoBehaviour
    {
        [SerializeField] private int _healthPoints;

        public void Damage(int damagePoints)
        {
            Debug.Log($"Taking {damagePoints} damage");
            _healthPoints -= damagePoints;
            if (_healthPoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}