using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPicker : MonoBehaviour
{
    [SerializeField] List<PowerupToShootingConfigs> powerupToShootingConfigs;
    [SerializeField] PowerupTypes initialPowerupType = PowerupTypes.Blue;

    Shooter shooter;
    PowerupTypes currentPowerupType;
    int currentShootingConfigIndex;
    Dictionary<PowerupTypes, List<ShootingConfigSO>> powerupTypeToShootingConfigs = new Dictionary<PowerupTypes, List<ShootingConfigSO>>();


    private void Awake()
    {
        shooter = GetComponent<Shooter>();
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
        if (powerupTypeToShootingConfigs.ContainsKey(powerupType))
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
    }
}
