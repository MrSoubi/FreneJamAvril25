using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    public RSE_OnClick RSE_OnClick;
    public RSE_OnAsteroidClicked RSE_OnAsteroidClicked;

    public int stock = 25;
    public int health = 100;

    public GameObject collectiblePrefab;

    private void OnMouseEnter()
    {
        RSE_OnClick.Trigger += OnClick;
    }

    private void OnMouseExit()
    {
        RSE_OnClick.Trigger -= OnClick;
    }

    private void OnClick()
    {
        RSE_OnAsteroidClicked.Trigger(this.gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < stock; i++)
        {
            Vector3 spawnPosition = new Vector3(transform.position.x + Random.Range(-10f, 10f), transform.position.y, transform.position.z + Random.Range(-10f, 10f));
            var collectible = Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);
            collectible.GetComponent<Rigidbody>().AddForce((collectible.transform.position - transform.position) * 100);
            
            collectible.transform.rotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
            collectible.GetComponent<Rigidbody>().AddTorque(Random.insideUnitSphere * 100);
        }
    }
}
