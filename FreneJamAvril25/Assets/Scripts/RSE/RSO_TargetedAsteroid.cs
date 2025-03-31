using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RSO_TargetedAsteroid", menuName = "RSO/RSO_TargetedAsteroid", order = 0)]
public class RSO_TargetedAsteroid : ScriptableObject
{
    public Action<GameObject> OnValueChanged;

    private GameObject target;

    public GameObject Value
    {
        get
        {
            return target;
        }
        set
        {
            if (target != value)
            {
                target = value;
                OnValueChanged?.Invoke(value);
            }
        }
    }
}
