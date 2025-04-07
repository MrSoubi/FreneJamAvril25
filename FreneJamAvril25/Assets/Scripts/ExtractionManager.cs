using System.Collections;
using UnityEngine;

public class ExtractionManager : MonoBehaviour
{
    public RSE_OnAsteroidClicked RSE_OnAsteroidClicked;

    public float range = 5;
    public int strength = 20;
    public float delay = 1;

    private void OnEnable()
    {
        RSE_OnAsteroidClicked.Trigger += OnAsteroidClicked;
    }

    private void OnDisable()
    {
        RSE_OnAsteroidClicked.Trigger -= OnAsteroidClicked;
    }

    private void OnAsteroidClicked(GameObject asteroid)
    {
        if (IsAsteroidOutOfRange(asteroid))
        {
            Debug.Log("Asteroid out of range: " + asteroid.name);
            return;
        }

        StartCoroutine(ExtractionCoroutine(asteroid.GetComponent<AsteroidBehavior>()));
    }


    private IEnumerator ExtractionCoroutine(AsteroidBehavior asteroid)
    {
        Debug.Log("Extraction started: " + asteroid.name);

        while (asteroid != null && !IsAsteroidOutOfRange(asteroid))
        {
            asteroid.TakeDamage(strength);
            Debug.Log("Extraction: " + asteroid.name);
            yield return new WaitForSeconds(delay);
        }

        Debug.Log("Extraction finished");
    }


    private bool IsAsteroidOutOfRange(GameObject asteroid)
    {
        return Vector3.Distance(asteroid.transform.position, transform.position) > range;
    }

    private bool IsAsteroidOutOfRange(AsteroidBehavior asteroid)
    {
        return Vector3.Distance(asteroid.transform.position, transform.position) > range;
    }
}
