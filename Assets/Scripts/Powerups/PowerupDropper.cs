using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupDropper : MonoBehaviour
{
    [SerializeField] List<GameObject> possiblePowerups;
    [SerializeField] float chanceToDrop = 0.2f;

    public void Drop()
    {
        float randomValue = Random.Range(0f, 1f);

        if (randomValue < chanceToDrop)
        {
            int randomPowerupIndex = Random.Range(0, possiblePowerups.Count);

            Instantiate(possiblePowerups[randomPowerupIndex],
                        transform.position,
                        Quaternion.identity);
        }
    }
}
