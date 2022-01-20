using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shot", fileName = "New Shot")]
public class ShotSO : ScriptableObject
{
    [SerializeField] float xOffset = 0f;
    [SerializeField] float speed = 0f;
    [SerializeField] Quaternion quaternion = Quaternion.identity;
    
    public float GetXOffset()
    {
        return xOffset;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public Quaternion GetQuaternion()
    {
        return quaternion;
    }
}
