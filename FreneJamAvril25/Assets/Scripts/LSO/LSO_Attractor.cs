using UnityEngine;

[CreateAssetMenu(fileName = ("LSO_Attractor"), menuName = "LSO/Attractor")]
public class LSO_Attractor : LogicScriptableObject
{
    public DSO_Attractor data;

    public override void Initialize(GameObject owner)
    {
        base.Initialize(owner);

        DSO_Attractor newData = ScriptableObject.CreateInstance<DSO_Attractor>();
        newData.m_Rigidbodies = data.m_Rigidbodies;
        data = newData;
    }

    public void OnTriggerEnter(Collider other)
    {
        CollectibleBehavior collectible;

        if (other.TryGetComponent<CollectibleBehavior>(out collectible))
        {
            Rigidbody collectibleRigidbody = collectible.gameObject.GetComponent<Rigidbody>();
            data.m_Rigidbodies.Add(collectibleRigidbody);
        }
    }

    public void FixedUpdate()
    {
        foreach (Rigidbody rb in data.m_Rigidbodies)
        {
            if (rb != null)
            {
                rb.AddForce(owner.transform.position - rb.position);
                Debug.Log(rb);
            }
        }
    }
}