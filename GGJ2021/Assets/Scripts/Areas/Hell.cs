using UnityEngine;

namespace Areas
{
    public class Hell : MonoBehaviour
    {
        private PlayerController _playerController;

        private void Start()
        {
            _playerController = FindObjectOfType<PlayerController>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Player))
                _playerController.Die();
        }
    }
}