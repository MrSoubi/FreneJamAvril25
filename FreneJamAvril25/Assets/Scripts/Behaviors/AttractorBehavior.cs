using UnityEngine;

public class AttractorBehavior : MonoBehaviour
{
    public LSO_Attractor logic;

    private void Awake()
    {
        DSO_Attractor newData = logic.data;
        logic = ScriptableObject.CreateInstance<LSO_Attractor>();
        logic.data = newData;
        logic.Initialize(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        logic.OnTriggerEnter(other);
    }

    void FixedUpdate()
    {
        logic.FixedUpdate();
    }
}
