using System.Collections;
using UnityEngine;

public class WarPlane : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _bombDropPoints;
    
    private PlayerController _playerController;
    private PlaneBombPool _bombPool;

    private Rigidbody2D _rigidbody;

    private Vector2 _targetPosition;
    private float _verticalPosition;
    private int _currentBombDropPosition;
    
    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _bombPool = FindObjectOfType<PlaneBombPool>();

        _rigidbody = GetComponent<Rigidbody2D>();
        _verticalPosition = transform.position.y;

        StartCoroutine(DropBombs());
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(CalculateNextPosition(Time.fixedDeltaTime));
    }

    private Vector2 CalculateNextPosition(float deltaTime)
    {
        var positionAbovePlayer = new Vector2(_playerController.transform.position.x, _verticalPosition);
        return Vector2.Lerp(transform.position, positionAbovePlayer, deltaTime * _speed);
    }

    private IEnumerator DropBombs()
    {
        const float mintTimeBetweenBombs = 0.5f;
        var timeBetweenBombs = CalculateTimeBetweenBombs();
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenBombs);

            DropBomb();
            if (timeBetweenBombs > mintTimeBetweenBombs)
                timeBetweenBombs = CalculateTimeBetweenBombs();
        }
    }

    private void DropBomb()
    {
        var bomb = _bombPool.GetNextItem();
        bomb.Drop(_bombDropPoints[_currentBombDropPosition++].position);
        _currentBombDropPosition %= _bombDropPoints.Length;
    }

    private static float CalculateTimeBetweenBombs()
    {
        const float maxTimeBetweenBombs = 3;
        // Reduce the frequency by .5 seconds every 10 seconds
        return maxTimeBetweenBombs - Time.timeSinceLevelLoad * 0.05f;
    }
}