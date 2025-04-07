using UnityEngine;

public class Collectible : MonoBehaviour
{
    public LSO_Collectible logic;

    private void Awake()
    {
        DSO_Collectible tmp = logic.data;
        logic = ScriptableObject.CreateInstance<LSO_Collectible>();
        logic.data = tmp;
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
