using UnityEngine;

public class LogicScriptableObject : ScriptableObject
{
    protected GameObject owner;

    public virtual void Initialize(GameObject owner)
    {
        this.owner = owner;
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        // Default implementation (if any)
    }

    public virtual void Destroy()
    {
        // Default implementation (if any)
    }

    public virtual void Enable()
    {
        // Default implementation (if any)
    }

    public virtual void Disable()
    {
        // Default implementation (if any)
    }

    public virtual void FixedUpdate()
    {
        // Default implementation (if any)
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        // Default implementation (if any)
    }
}