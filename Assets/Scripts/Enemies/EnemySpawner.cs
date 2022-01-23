using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping = true;
    [SerializeField] WaveConfigSO bossConfig;
    WaveConfigSO currentWave;
    

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    private IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (var wave in waveConfigs)
            {
                currentWave = wave;

                yield return SpawnEnemyWave(currentWave);
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while (isLooping);

        if (bossConfig != null)
        {
            currentWave = bossConfig;

            yield return new WaitForSeconds(1.5f);
            yield return SpawnEnemyWave(bossConfig);
        }
    }

    private IEnumerator SpawnEnemyWave(WaveConfigSO waveConfig)
    {
        for (int i = 0; i < waveConfig.GetEnemyCount(); i++)
        {
            Instantiate(waveConfig.GetEnemyPrefab(i),
                        waveConfig.GetStartingWaypoint().position,
                        Quaternion.identity,
                        transform);

            yield return new WaitForSeconds(waveConfig.GetRandomSpawnTime());
        }
    }
}
