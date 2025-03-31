using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_OnAsteroidClicked", menuName = "RSE/OnAsteroidClicked")]
public class RSE_OnAsteroidClicked : ScriptableObject
{
    public Action<GameObject> Trigger;
}
