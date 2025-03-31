using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_OnResourceCollected", menuName = "RSE/RSE_OnResourceCollected", order = 1)]
public class RSE_OnResourceCollected : ScriptableObject
{
    public Action<int> Trigger;
}
