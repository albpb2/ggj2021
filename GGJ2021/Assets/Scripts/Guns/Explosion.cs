using System;
using FMODUnity;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _maxDistanceToHurtPlayer;
    [SerializeField] private int _damage;
    
    private PlayerController _playerController;
    
    private StudioEventEmitter _studioEventEmitter;

    private void Awake()
    {
        _studioEventEmitter = GetComponent<StudioEventEmitter>();
    }

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }

    public void Enable()
    {
        gameObject.SetActive(true);
        _studioEventEmitter.Play();
    }

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