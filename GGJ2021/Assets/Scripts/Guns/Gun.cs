using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private ProjectilePool _projectilePool;
    [SerializeField] private float _reloadTime;

    private float _lastShootTime;

    public void Shoot(Transform shootPoint)
    {
        if (!CanShoot())
            return;
        
        var projectile = _projectilePool.GetNextProjectile();
        projectile.transform.position = shootPoint.position;
        projectile.gameObject.SetActive(true);
    }

    private bool CanShoot()
    {
        return Time.deltaTime - _lastShootTime > _reloadTime;
    }
}