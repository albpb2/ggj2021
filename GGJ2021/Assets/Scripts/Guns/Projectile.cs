﻿using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Rigidbody2D _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger)
        {
            Debug.Log("I hit something!");
            Disable();
        }
    }

    public void Shoot(Vector2 origin, Vector2 direction)
    {
        transform.position = origin;
        gameObject.SetActive(true);
        _rigidbody.velocity = direction * _speed;
        Debug.Log("BANG");
        StartCoroutine(DisableAfterTime());
    }

    private IEnumerator DisableAfterTime()
    {
        const int millisecondsDuration = 500;
        yield return new WaitForSeconds(millisecondsDuration / 1000f);
        Debug.Log("Disabling after time");
        Disable();
    }

    private void Disable()
    {
        StopAllCoroutines();
        gameObject.SetActive(false);
    }
}