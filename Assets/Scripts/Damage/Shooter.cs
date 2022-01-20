using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] ShootingConfigSO shootingConfig;

    [Header("AI")]
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;
    [SerializeField] bool useAI;

    [HideInInspector] public bool isFiring;
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject projectilePrefab = shootingConfig.GetProjectilePrefab();
            float baseFiringRate = shootingConfig.GetBaseFiringRate();

            foreach (var shot in shootingConfig.GetShots())
            {
                GameObject instance = Instantiate(projectilePrefab, 
                                                  transform.position + new Vector3(shot.GetXOffset(), 0, 0), 
                                                  shot.GetQuaternion());
                Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    rb.velocity = instance.transform.up * shot.GetSpeed();
                }

                Destroy(instance, shootingConfig.GetProjectileLifeTime());
            }

            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance,
                                                      baseFiringRate + firingRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);

            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }
}
