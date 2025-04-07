using UnityEngine;

[CreateAssetMenu(fileName = "DSO_Cargo", menuName = "DSO/Cargo")]
public class DSO_Cargo : DataScriptableObject<CargoBehavior>
{
    public RSE_OnResourceCollected OnResourceCollected;

    public int maxStock = 100;
    public int currentStock = 0;
}