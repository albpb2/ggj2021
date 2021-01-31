using System;
using FMODUnity;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private ProjectilePool _projectilePool;
    [SerializeField] private float _reloadTime;

    private StudioEventEmitter _studioEventEmitter;

    private float _lastShootTime;

    private void Awake()
    {
        _studioEventEmitter = GetComponent<StudioEventEmitter>();
    }

    public void Shoot(Transform shootPoint, Vector2 direction)
    {
        if (!CanShoot())
            return;
        
        if (_studioEventEmitter != null)
            _studioEventEmitter.Play();
        
        var projectile = _projectilePool.GetNextItem();
        projectile.Shoot(shootPoint.position, direction);
        _lastShootTime = Time.time;
    }

    private bool CanShoot()
    {
        return Time.time - _lastShootTime > _reloadTime;
    }
}