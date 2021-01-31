using System;
using FMODUnity;
using Input;
using Inventory;
using Pause;
using Player;
using Player.State;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float GroundCheckRadius = .01f;

    public delegate void PlayerDiedEventHandler();
    public event PlayerDiedEventHandler OnPlayerDied;
    
    [SerializeField] private float _velocity = 1;
    [SerializeField] private float _jumpForce = 1;
    [SerializeField] private int _healthPoints = 100;
    [SerializeField] private float _maxFallDistance;
    [SerializeField] private Transform _groundDetector;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Gun _equippedGun;
    [SerializeField] private Collider2D _hitbox;
    [SerializeField] private Collider2D _crouchedHitbox;
    
    [Header("Event emitters")]
    [SerializeField] private StudioEventEmitter _jumpEventEmitter;
    [SerializeField] private StudioEventEmitter _teleportEventemitter;
    
    private PlayerStateProvider _playerStateProvider;
    private InputHandler _inputHandler;
    private PauseManager _pauseManager;
    
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private IPlayerState _state;
    private Vector2 _movement;
    private bool _isGrounded;
    private bool _lookingRight;
    private PickableItem _pickableItem;

    public bool IsGrounded => _isGrounded;
    public bool IsFalling => !_isGrounded && _rigidbody.velocity.y < -GlobalConstants.FloatTolerance;
    public Vector2 Velocity => _rigidbody.velocity;
    public Gun EquippedGun => _equippedGun;

    private void Awake()
    {
        _inputHandler = FindObjectOfType<InputHandler>();
        _pauseManager = FindObjectOfType<PauseManager>();
        _playerStateProvider = new PlayerStateProvider(this, _inputHandler);

        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _teleportEventemitter.Play();
        PlayAnimationOnce(PlayerAnimationTriggers.Teleport);
        _isGrounded = true;
        _lookingRight = true;
    }

    private void Update()
    {
        if (_pauseManager.IsPaused() || _state == null)
            return;

        SetMovement(Vector2.zero);
        _state = _state.Update();

        if (ShouldPickItem())
        {
            _pickableItem.PickItem();
        }
    }

    private void FixedUpdate()
    {
        var horizontalVelocity = _movement.x * _velocity;
        _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
        FixOrientation();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.PickableItem))
            _pickableItem = other.GetComponent<PickableItem>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(Tags.PickableItem))
            _pickableItem = null;
    }

    public void Activate()
    {
        _state = _playerStateProvider.GetIdleState().EnterState();
    }

    public void SetMovement(Vector2 movement) => _movement = movement;

    public void Jump()
    {
        _jumpEventEmitter.Play();
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    public void Crouch()
    {
        _hitbox.enabled = false;
        _crouchedHitbox.enabled = true;
    }

    public void StopCrouching()
    {
        _hitbox.enabled = true;
        _crouchedHitbox.enabled = false;
    }

    public void Shoot()
    {
        if (_equippedGun != null)
            _equippedGun.Shoot(_shootingPoint, transform.right);
    }

    public void PlayAnimationOnce(string triggerName) => _animator.SetTrigger(triggerName);

    public void PlayAnimation(string triggerName) => _animator.SetBool(triggerName, true);
    
    public void StopAnimation(string triggerName) => _animator.SetBool(triggerName, false);

    public void Hurt(int damage)
    {
        _healthPoints -= damage;
        _healthPoints = Math.Max(_healthPoints, 0);
        if (_healthPoints == 0)
        {
            Die();
        }
    }
    
    public void Die()
    {
        OnPlayerDied?.Invoke();
    }

    public void HandleFall(float initialHeight)
    {
        var fallDistance = initialHeight - transform.position.y;
        if (fallDistance > _maxFallDistance)
            Die();
    }

    public void EquipGun(Gun gun)
    {
        Debug.Log($"Equipping {gun.name}");
        _equippedGun = gun;
    }

    private void FixOrientation()
    {
        var horizontalInput = _inputHandler.GetHorizontalAxisValue();
        if (_lookingRight && horizontalInput < 0 || !_lookingRight && horizontalInput > 0)
            Flip();
    }

    private void Flip()
    {
        _lookingRight = !_lookingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private bool ShouldPickItem() => _pickableItem != null && _inputHandler.IsFire3Pressed();
}
