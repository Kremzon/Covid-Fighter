using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPicker : MonoBehaviour
{
    [SerializeField] List<PowerupToShootingConfigs> powerupToShootingConfigs;
    [SerializeField] PowerupTypes initialPowerupType = PowerupTypes.Blue;

    Shooter shooter;
    Health health;
    PowerupTypes currentPowerupType;
    int currentShootingConfigIndex;
    Dictionary<PowerupTypes, List<ShootingConfigSO>> powerupTypeToShootingConfigs = new Dictionary<PowerupTypes, List<ShootingConfigSO>>();


    private void Awake()
    {
        shooter = GetComponent<Shooter>();
        health = GetComponent<Health>();
    }

    private void Start()
    {
        currentPowerupType = initialPowerupType;
        currentShootingConfigIndex = 0;

        foreach (var powerupToShootingConfigs in powerupToShootingConfigs)
        {
            powerupTypeToShootingConfigs[powerupToShootingConfigs.GetPowerupType()] = powerupToShootingConfigs.GetShootingConfigs();
        }

        shooter.SetShootingConfig(powerupTypeToShootingConfigs[currentPowerupType][currentShootingConfigIndex]);
    }

    public void Pickup(PowerupTypes powerupType)
    {
        if (powerupType == PowerupTypes.Health)
        {
            health.IncreaseHealth(30);
        }
        else if (powerupTypeToShootingConfigs.ContainsKey(powerupType))
        {
            
            if (currentPowerupType != powerupType)
            {
                currentPowerupType = powerupType;
                currentShootingConfigIndex = 0;
            }
            else if (currentShootingConfigIndex + 1 < powerupTypeToShootingConfigs[currentPowerupType].Count)
            {
                currentShootingConfigIndex++;
            }

            shooter.SetShootingConfig(powerupTypeToShootingConfigs[currentPowerupType][currentShootingConfigIndex]);
        }
        else
        {
            Debug.LogError(string.Format("Recieved powerup type {0} that isn't handled", powerupType));
        }
    }
}
