using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private ProjectilePool _projectilePool;
    [SerializeField] private float _reloadTime;

    private float _lastShootTime;

    public void Shoot(Transform shootPoint, Vector2 direction)
    {
        if (!CanShoot())
            return;
        
        var projectile = _projectilePool.GetNextProjectile();
        projectile.Shoot(shootPoint.position, direction);
    }

    private bool CanShoot()
    {
        return Time.deltaTime - _lastShootTime > _reloadTime;
    }
}