using UnityEngine;

namespace Player
{
    public class PlayerGroundChecker : MonoBehaviour
    {
        private const float GroundCheckRadius = .05f;

        [SerializeField] private Transform _groundDetector;
        [SerializeField] private LayerMask _groundLayer;

        private int _currentGroundCollidersCount;
        private bool _isGrounded;

        public bool IsGrounded => _isGrounded;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(Tags.Ground))
            {
                _currentGroundCollidersCount++;
                if (Physics2D.OverlapCircle(_groundDetector.position, GroundCheckRadius, _groundLayer))
                    _isGrounded = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(Tags.Ground))
            {
                _currentGroundCollidersCount--;
                if (_currentGroundCollidersCount == 0) 
                    _isGrounded = false;
            }
        }
    }
}