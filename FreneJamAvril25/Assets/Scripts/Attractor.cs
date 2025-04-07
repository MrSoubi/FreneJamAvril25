using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    List<Rigidbody> m_Rigidbodies = new List<Rigidbody>();

    private void OnTriggerEnter(Collider other)
    {
        CollectibleBehavior collectible;

        if (other.TryGetComponent<CollectibleBehavior>(out collectible))
        {
            Rigidbody collectibleRigidbody = collectible.gameObject.GetComponent<Rigidbody>();
            m_Rigidbodies.Add(collectibleRigidbody);
        }
    }

    void FixedUpdate()
    {
        foreach (Rigidbody rb in m_Rigidbodies)
        {
            if (rb != null)
            {
                rb.AddForce(transform.position - rb.position);
                Debug.Log(rb);
            }
        }
    }
}
