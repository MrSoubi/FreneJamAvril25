using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "LSO_Extractor", menuName = "LSO/Extractor")]
public class LSO_Extractor : LogicScriptableObject
{
    public DSO_Extractor data;

    public override void Initialize(GameObject owner)
    {
        base.Initialize(owner);

        DSO_Extractor newData = ScriptableObject.CreateInstance<DSO_Extractor>();
        newData.OnAsteroidClicked = data.OnAsteroidClicked;
        newData.range = data.range;
        newData.strength = data.strength;
        newData.delay = data.delay;
        newData.laserPrefab = data.laserPrefab;
        data = newData;
    }

    public void Enable()
    {
        data.OnAsteroidClicked.Trigger += OnAsteroidClicked;
    }

    public void Disable()
    {
        data.OnAsteroidClicked.Trigger -= OnAsteroidClicked;
    }

    private void OnAsteroidClicked(GameObject asteroid)
    {
        if (IsAsteroidOutOfRange(asteroid))
        {
            Debug.Log("Asteroid out of range: " + asteroid.name + " at " + Vector3.Distance(asteroid.transform.position, owner.transform.position) + "meters.");
            return;
        }

        owner.GetComponent<ExtractorBehavior>().CoroutineStarter(asteroid.GetComponent<AsteroidBehavior>());
    }


    public IEnumerator ExtractionCoroutine(AsteroidBehavior asteroid)
    {
        Debug.Log("Extraction started: " + asteroid.name);

        GameObject laser = Instantiate(data.laserPrefab, owner.transform.position, Quaternion.identity);
        LineRenderer lineRenderer = laser.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, owner.transform.position);
        lineRenderer.SetPosition(1, asteroid.transform.position);

        while (asteroid != null && !IsAsteroidOutOfRange(asteroid))
        {
            lineRenderer.SetPosition(0, owner.transform.position);
            asteroid.TakeDamage(data.strength);
            Debug.Log("Extraction: " + asteroid.name);
            yield return new WaitForSeconds(data.delay);
        }

        lineRenderer.enabled = false;
        Debug.Log("Extraction finished");
    }


    private bool IsAsteroidOutOfRange(GameObject asteroid)
    {
        Debug.Log(asteroid);
        Debug.Log(owner);
        return Vector3.Distance(asteroid.transform.position, owner.transform.position) > data.range;
    }

    private bool IsAsteroidOutOfRange(AsteroidBehavior asteroid)
    {
        return Vector3.Distance(asteroid.transform.position, owner.transform.position) > data.range;
    }
}