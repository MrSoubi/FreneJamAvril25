using UnityEngine;

public class DataScriptableObject<T> : ScriptableObject
{
    [HideInInspector]
    public GameObject owner;
}