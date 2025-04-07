using UnityEngine;

[CreateAssetMenu(fileName = "DSO_Collectible", menuName = "DSO/Collectible")]
public class DSO_Collectible : ScriptableObject
{
    public int stockValue = 10;
    public RSE_OnResourceCollected OnResourceCollected;
}