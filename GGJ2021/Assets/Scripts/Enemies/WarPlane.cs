using System.Collections;
using UnityEngine;

public class WarPlane : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _bombDropPoints;
    [SerializeField] private float _distanceWithPlayer;
    [SerializeField] private float _minSecondsBetweenBombs;
    [SerializeField] private float _maxSecondsBetweenBombs;
    [SerializeField] private float _secondsToReachFullBombSpeed;
    
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
        var positionAbovePlayer = new Vector2(_playerController.transform.position.x + _distanceWithPlayer, _verticalPosition);
        return Vector2.Lerp(transform.position, positionAbovePlayer, deltaTime * _speed);
    }

    private IEnumerator DropBombs()
    {
        var timeBetweenBombs = CalculateTimeBetweenBombs();
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenBombs);

            DropBomb();
            if (timeBetweenBombs > _minSecondsBetweenBombs)
                timeBetweenBombs = CalculateTimeBetweenBombs();
        }
    }

    private void DropBomb()
    {
        var bomb = _bombPool.GetNextItem();
        bomb.Drop(_bombDropPoints[_currentBombDropPosition++].position);
        _currentBombDropPosition %= _bombDropPoints.Length;
    }

    private float CalculateTimeBetweenBombs()
    {
        var delta = (_maxSecondsBetweenBombs - _minSecondsBetweenBombs) 
            * Time.timeSinceLevelLoad / _secondsToReachFullBombSpeed;
        return _maxSecondsBetweenBombs - delta;
    }
}