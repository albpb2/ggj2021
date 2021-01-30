using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private int _numOfInstances;

    private Projectile[] _projectiles;
    private int _currentProjectileIndex;

    private void Start()
    {
        _projectiles = new Projectile[_numOfInstances];
        for (var i = 0; i < _numOfInstances; i++)
        {
            _projectiles[i] = Instantiate(_projectilePrefab).GetComponent<Projectile>();
            _projectiles[i].gameObject.SetActive(false);
        }
    }

    public Projectile GetNextProjectile()
    {
        var projectile =  _projectiles[_currentProjectileIndex++];

        _currentProjectileIndex = _currentProjectileIndex % _numOfInstances;

        return projectile;
    } 
}