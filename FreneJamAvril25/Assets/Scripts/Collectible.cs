using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public RSE_OnResourceCollected RSE_OnResourceCollected;

    public int stockValue = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<SpaceshipController>() != null)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        RSE_OnResourceCollected.Trigger?.Invoke(stockValue);
    }
}
