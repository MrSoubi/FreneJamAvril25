using UnityEngine;

[CreateAssetMenu(fileName = "LSO_Collectible", menuName = "LSO/Collectible")]
public class LSO_Collectible : LogicScriptableObject
{
    public DSO_Collectible data;

    public override void Initialize(GameObject owner)
    {
        base.Initialize(owner);

        DSO_Collectible newData = ScriptableObject.CreateInstance<DSO_Collectible>();
        newData.OnResourceCollected = data.OnResourceCollected;
        newData.stockValue = data.stockValue;
        data = newData;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (collision.gameObject.GetComponent<SpaceshipController>() != null)
        {
            Destroy(owner);
        }
    }

    public void Destroy()
    {
        data.OnResourceCollected.Trigger?.Invoke(data.stockValue);
    }
}