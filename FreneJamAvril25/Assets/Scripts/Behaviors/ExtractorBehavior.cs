using UnityEngine;

public class ExtractorBehavior : MonoBehaviour
{
    public LSO_Extractor logic;

    private void Awake()
    {
        DSO_Extractor newData = logic.data;
        logic = ScriptableObject.CreateInstance<LSO_Extractor>();
        logic.data = newData;
        logic.Initialize(gameObject);
    }

    private void OnEnable()
    {
        logic.Enable();
    }

    private void OnDisable()
    {
        logic.Disable();
    }

    public void CoroutineStarter(AsteroidBehavior asteroid)
    {
        StartCoroutine(logic.ExtractionCoroutine(asteroid));
    }
}
