using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_OnClick", menuName = "RSE/OnClick")]
public class RSE_OnClick : ScriptableObject
{
    public Action Trigger;
}
