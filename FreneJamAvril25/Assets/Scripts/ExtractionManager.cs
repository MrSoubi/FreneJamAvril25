using UnityEngine;

public class ExtractionManager : MonoBehaviour
{
    public LSO_Extraction logic;

    private void Awake()
    {
        DSO_Extraction newData = logic.data;
        logic = ScriptableObject.CreateInstance<LSO_Extraction>();
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
