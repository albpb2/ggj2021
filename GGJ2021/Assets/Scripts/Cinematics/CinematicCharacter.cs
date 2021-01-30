using UnityEngine;

public class CinematicCharacter : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
        
    private Movement _currentMovement;

    public Movement CurrentMovement => _currentMovement;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_currentMovement != null)
        {
            var nextStep = CalculateNextStep(Time.fixedDeltaTime);
            _rigidbody.MovePosition(nextStep);
            if (HasArrivedAtTargetPosition())
            {
                _currentMovement = null;
            }
        }
    }

    public void Move(Movement movement)
    {
        _currentMovement = movement;
    }

    private Vector2 CalculateNextStep(float deltaTime)
    {
        return Vector2.MoveTowards(
            transform.position,
            _currentMovement.targetPosition.position,
            _currentMovement.speed * deltaTime);
    }

    private Vector3 GetDirectionVector() => (_currentMovement.targetPosition.position - transform.position).normalized;

    private bool HasArrivedAtTargetPosition()
    {
        const float distancePrecision = 0.01f;
        return Vector2.Distance(_currentMovement.targetPosition.position, transform.position) < distancePrecision;
    }
}