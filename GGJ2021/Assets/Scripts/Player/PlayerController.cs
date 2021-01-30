using Input;
using Player.State;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float GroundCheckRadius = .01f;
    
    [SerializeField] private float _velocity = 1;
    [SerializeField] private float _jumpForce = 1;
    [SerializeField] private Transform _groundDetector;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Gun _equippedGun;
    
    private PlayerStateProvider _playerStateProvider;
    private InputHandler _inputHandler;
    
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private IPlayerState _state;
    private Vector2 _movement;
    private bool _isGrounded;
    private bool _lookingRight;

    public bool IsGrounded => _isGrounded;

    private void Awake()
    {
        _inputHandler = FindObjectOfType<InputHandler>();
        _playerStateProvider = new PlayerStateProvider(this, _inputHandler);

        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _state = _playerStateProvider.GetWalkingState();
        _isGrounded = true;
        _lookingRight = true;
    }

    private void Update()
    {
        _state = _state.Update();
        FixOrientation();
    }

    private void FixedUpdate()
    {
        var horizontalVelocity = _movement.x * _velocity;
        _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
    }

    public void SetMovement(Vector2 movement) => _movement = movement;

    public void Jump() => _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

    public void Shoot()
    {
        if (_equippedGun != null)
            _equippedGun.Shoot(_shootingPoint, transform.right);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Tags.Ground) && Physics2D.OverlapCircle(_groundDetector.position, GroundCheckRadius, _groundLayer))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Tags.Ground) && !Physics2D.OverlapCircle(_groundDetector.position, GroundCheckRadius, _groundLayer))
        {
            _isGrounded = false;
        }
    }

    private void FixOrientation()
    {
        if (_lookingRight && _movement.x < 0 || !_lookingRight && _movement.x > 0)
            Flip();
    }

    private void Flip()
    {
        _lookingRight = !_lookingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
