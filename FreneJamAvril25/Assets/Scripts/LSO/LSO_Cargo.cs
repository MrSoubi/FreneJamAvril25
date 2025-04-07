using UnityEngine;

[CreateAssetMenu(fileName = "LSO_Cargo", menuName = "LSO/Cargo")]
public class LSO_Cargo : LogicScriptableObject
{
    public DSO_Cargo data;

    public override void Initialize(GameObject owner)
    {
        base.Initialize(owner);

        DSO_Cargo newData = ScriptableObject.CreateInstance<DSO_Cargo>();
        newData.maxStock = data.maxStock;
        newData.currentStock = data.currentStock;
        newData.OnResourceCollected = data.OnResourceCollected;
        data = newData;
    }

    public override void Enable()
    {
        data.OnResourceCollected.Trigger += AddStock;
    }

    public override void Disable()
    {
        data.OnResourceCollected.Trigger -= AddStock;
    }

    public void AddStock(int amount)
    {
        data.currentStock += amount;
        if (data.currentStock > data.maxStock)
        {
            data.currentStock = data.maxStock;
        }

        Debug.Log("Current stock: " + data.currentStock);
    }
}