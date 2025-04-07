using UnityEngine;

[CreateAssetMenu(fileName = "DSO_Extractor", menuName = "DSO/Extractor")]
public class DSO_Extractor : ScriptableObject
{
    public RSE_OnAsteroidClicked OnAsteroidClicked;

    public float range = 5;
    public int strength = 20;
    public float delay = 1;

    public GameObject laserPrefab;
}