using UnityEngine;

[CreateAssetMenu(fileName = "DSO_Extraction", menuName = "DSO/Extraction")]
public class DSO_Extraction : ScriptableObject
{
    public RSE_OnAsteroidClicked OnAsteroidClicked;

    public float range = 5;
    public int strength = 20;
    public float delay = 1;
}