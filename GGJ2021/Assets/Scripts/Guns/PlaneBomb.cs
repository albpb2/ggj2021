using System;
using UnityEngine;

public class PlaneBomb : MonoBehaviour
{
    [SerializeField] private float _windImpact = 0.1f;

    private ExplosionPool _explosionPool;
    
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _explosionPool = FindObjectOfType<ExplosionPool>();
    }

    private void FixedUpdate()
    {
        var currentPosition = _rigidbody.position;
        _rigidbody.MovePosition(new Vector2(currentPosition.x - _windImpact * Time.deltaTime, currentPosition.y));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        gameObject.SetActive(false);
        var explosion = _explosionPool.GetNextItem();
        explosion.SetPosition(transform.position);
        explosion.Enable();
    }

    public void Drop(Vector2 dropPosition)
    {
        transform.position = dropPosition;
        gameObject.SetActive(true);
    }
}