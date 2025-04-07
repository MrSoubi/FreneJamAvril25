using UnityEngine;

[CreateAssetMenu(fileName = "DSO_Asteroid", menuName = "DSO/Asteroid")]
public class DSO_Asteroid : ScriptableObject
{
    public RSE_OnClick OnClick;
    public RSE_OnAsteroidClicked OnAsteroidClicked;

    public int stock = 25;
    public int health = 100;

    public GameObject collectiblePrefab;
}