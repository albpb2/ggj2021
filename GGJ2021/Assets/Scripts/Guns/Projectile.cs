using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Disable();
    }

    private void Move()
    {
        _rigidbody.velocity = transform.right * _speed;
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}