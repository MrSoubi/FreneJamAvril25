using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "LSO_Extraction", menuName = "LSO/Extraction")]
public class LSO_Extraction : LogicScriptableObject
{
    public DSO_Extraction data;

    public override void Initialize(GameObject owner)
    {
        base.Initialize(owner);

        DSO_Extraction newData = ScriptableObject.CreateInstance<DSO_Extraction>();
        newData.OnAsteroidClicked = data.OnAsteroidClicked;
        newData.range = data.range;
        newData.strength = data.strength;
        newData.delay = data.delay;
        data = newData;
    }

    public override void Enable()
    {
        data.OnAsteroidClicked.Trigger += OnAsteroidClicked;
    }

    public override void Disable()
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

        owner.GetComponent<ExtractionManager>().CoroutineStarter(asteroid.GetComponent<AsteroidBehavior>());
    }


    public IEnumerator ExtractionCoroutine(AsteroidBehavior asteroid)
    {
        Debug.Log("Extraction started: " + asteroid.name);

        while (asteroid != null && !IsAsteroidOutOfRange(asteroid))
        {
            asteroid.TakeDamage(data.strength);
            Debug.Log("Extraction: " + asteroid.name);
            yield return new WaitForSeconds(data.delay);
        }

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