﻿using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private ProjectilePool _projectilePool;
    [SerializeField] private float _reloadTime;

    private float _lastShootTime;

    public void Shoot(Transform shootPoint, Vector2 direction)
    {
        if (!CanShoot())
            return;
        
        var projectile = _projectilePool.GetNextItem();
        projectile.Shoot(shootPoint.position, direction);
        _lastShootTime = Time.time;
    }

    private bool CanShoot()
    {
        return Time.time - _lastShootTime > _reloadTime;
    }
}