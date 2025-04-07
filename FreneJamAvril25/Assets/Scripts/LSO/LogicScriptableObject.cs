using UnityEngine;

public class LogicScriptableObject : ScriptableObject
{
    protected GameObject owner;

    public virtual void Initialize(GameObject owner)
    {
        this.owner = owner;
    }
}