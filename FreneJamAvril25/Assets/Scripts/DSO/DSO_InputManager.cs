using UnityEngine;

[CreateAssetMenu(fileName = "DSO_InputManager", menuName = "DSO/InputManager")]
public class DSO_InputManager : DataScriptableObject<InputManager>
{
    public RSE_OnClick RSE_OnClick;
    public LayerMask layerMask;
}