using System;
using System.Collections;
using UnityEngine;
using Random = System.Random;

namespace Guns
{
    public class Heart : MonoBehaviour
    {
        private Random _random;
        
        private Rigidbody2D _rigidbody;

        private bool _applyRightForce;

        private void Awake()
        {
            _random = new Random();
            
            _rigidbody = GetComponent<Rigidbody2D>();

            StartCoroutine(ApplyRandomForces());
        }

        private IEnumerator ApplyRandomForces()
        {
            while (true)
            {
                var randomTimeSeconds = _random.Next(2, 4);
                yield return new WaitForSeconds(randomTimeSeconds);
                var randomForceMagnitudeBase = _random.NextDouble();
                var randomForceMagnitude = 0.5 + 2.5 * randomForceMagnitudeBase;
                if (!_applyRightForce)
                    randomForceMagnitude *= -1;
                _rigidbody.AddForce(new Vector2((float)randomForceMagnitude, .1f), ForceMode2D.Impulse);
                _applyRightForce = !_applyRightForce;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Ground))
                Destroy(gameObject);
        }
    }
}