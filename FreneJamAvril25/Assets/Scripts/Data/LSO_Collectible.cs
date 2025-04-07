using UnityEngine;

[CreateAssetMenu(fileName = "LSO_Collectible", menuName = "LSO/Collectible")]
public class LSO_Collectible : LogicScriptableObject
{
    public DSO_Collectible data;

    public override void Initialize(GameObject owner)
    {
        base.Initialize(owner);

        RSE_OnResourceCollected tmp = this.data.OnResourceCollected;
        this.data = ScriptableObject.CreateInstance<DSO_Collectible>();
        this.data.OnResourceCollected = tmp;
    }

    public override void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (collision.gameObject.GetComponent<SpaceshipController>() != null)
        {
            Destroy(owner);
        }
    }

    public override void Destroy()
    {
        data.OnResourceCollected.Trigger?.Invoke(data.stockValue);
    }
}