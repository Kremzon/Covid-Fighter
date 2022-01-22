using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerup To Shooting Config", fileName = "New Powerup To Shooting Config")]
public class PowerupToShootingConfigs : ScriptableObject
{
    [SerializeField] PowerupTypes powerupType;
    [SerializeField] List<ShootingConfigSO> shootingConfigs;

    public PowerupTypes GetPowerupType()
    {
        return powerupType;
    }

    public List<ShootingConfigSO> GetShootingConfigs()
    {
        return shootingConfigs;
    }
}
