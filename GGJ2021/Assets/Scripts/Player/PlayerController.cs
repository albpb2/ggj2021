using Input;
using Player.State;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _velocity;
    
    private PlayerStateProvider _playerStateProvider;
    private InputHandler _inputHandler;
    
    private Rigidbody2D _rigidbody;

    private IPlayerState _state;
    private Vector2 _movement;

    private void Awake()
    {
        _inputHandler = FindObjectOfType<InputHandler>();
        _playerStateProvider = new PlayerStateProvider(this, _inputHandler);

        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _state = _playerStateProvider.GetWalkingState();
    }

    private void Update()
    {
        _state = _state.Update();
    }

    private void FixedUpdate()
    {
        Debug.Log($"Force: {_movement}");
        _rigidbody.velocity = _velocity * _movement;
    }

    public void SetMovement(Vector2 movement) => _movement = movement;
}
