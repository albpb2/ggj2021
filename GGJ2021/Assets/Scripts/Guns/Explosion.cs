using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _maxDistanceToHurtPlayer;
    [SerializeField] private int _damage;
    
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }

    public void Enable() => gameObject.SetActive(true);

    // Used from animation
    public void Disable() => gameObject.SetActive(false);

    // Used from animation
    public void TryHurtPlayer()
    {
        if (Vector2.Distance(transform.position, _playerController.transform.position) < _maxDistanceToHurtPlayer)
        {
            _playerController.Hurt(_damage);
        }
    }
}