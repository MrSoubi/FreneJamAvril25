using UnityEngine;

[CreateAssetMenu(fileName = "DSO_SpaceshipController", menuName = "DSO/SpaceshipController")]
public class DSO_SpaceshipController : DataScriptableObject<SpaceshipController>
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 3f;
}