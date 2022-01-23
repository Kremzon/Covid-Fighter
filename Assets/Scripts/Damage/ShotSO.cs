using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shot", fileName = "New Shot")]
public class ShotSO : ScriptableObject
{
    [SerializeField] float xOffset = 0f;
    [SerializeField] Quaternion quaternion = Quaternion.identity;
    
    public float GetXOffset()
    {
        return xOffset;
    }

    public Quaternion GetQuaternion()
    {
        return quaternion;
    }
}
