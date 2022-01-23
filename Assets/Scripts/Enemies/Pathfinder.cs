using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;
    bool isInBackwardsLoop = false;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FllowPath();
    }

    private void FllowPath()
    {
        if (waypointIndex < waypoints.Count && waypointIndex >= 0)
        {
            Vector3 targetPoistion = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPoistion, delta);

            if (transform.position == targetPoistion)
            {
                if (isInBackwardsLoop)
                {
                    waypointIndex--;
                }
                else
                {
                    waypointIndex++;
                }
            }
        }
        else
        {
            if (waveConfig.GetShouldLoop())
            {
                if (isInBackwardsLoop)
                {
                    isInBackwardsLoop = false;
                    waypointIndex++;
                }
                else
                {
                    isInBackwardsLoop = true;
                    waypointIndex--;
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
