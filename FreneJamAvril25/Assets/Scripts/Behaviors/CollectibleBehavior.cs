using UnityEngine;

public class CollectibleBehavior : MonoBehaviour
{
    public LSO_Collectible logic;

    private void Awake()
    {
        DSO_Collectible newLogic = logic.data;
        logic = ScriptableObject.CreateInstance<LSO_Collectible>();
        logic.data = newLogic;
        logic.Initialize(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        logic.OnCollisionEnter(collision);
    }

    private void OnDestroy()
    {
        logic.Destroy();
    }
}
