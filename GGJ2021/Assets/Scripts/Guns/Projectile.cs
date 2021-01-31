﻿using System.Collections;
using Enemies;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damagePoints;
    
    private PlayerController _playerController;
    
    private Rigidbody2D _rigidbody;
    
    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.Player))
        {
            _playerController.Hurt(_damagePoints);
            Disable();
            return;
        }

        if (!other.isTrigger)
        {
            var destructibleComponent = other.GetComponent<Destructible>();
            if (destructibleComponent != null)
                destructibleComponent.Damage(_damagePoints);
            Disable();
        }
    }

    public void Shoot(Vector2 origin, Vector2 direction)
    {
        transform.position = origin;
        gameObject.SetActive(true);
        _rigidbody.velocity = direction * _speed;
        StartCoroutine(DisableAfterTime());
    }

    private IEnumerator DisableAfterTime()
    {
        const int millisecondsDuration = 500;
        yield return new WaitForSeconds(millisecondsDuration / 1000f);
        Disable();
    }

    private void Disable()
    {
        StopAllCoroutines();
        gameObject.SetActive(false);
    }
}