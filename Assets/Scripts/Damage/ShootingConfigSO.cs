using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shooting Config", fileName = "New Shooting Config")]
public class ShootingConfigSO : ScriptableObject
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] List<ShotSO> shots;
    [SerializeField] float baseFiringRate = 0.2f;
    [SerializeField] float projectileLifetime = 5f;

    public List<ShotSO> GetShots()
    {
        return shots;
    }

    public GameObject GetProjectilePrefab()
    {
        return projectilePrefab;
    }

    public float GetBaseFiringRate()
    {
        return baseFiringRate;
    }

    public float GetProjectileLifeTime()
    {
        return projectileLifetime;
    }
}
