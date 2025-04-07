using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public LSO_InputManager logic;

    private void Awake()
    {
        DSO_InputManager newData = logic.data;
        logic = ScriptableObject.CreateInstance<LSO_InputManager>();
        logic.data = newData;
        logic.Initialize(gameObject);
    }

    void Update()
    {
        logic.Update();
    }
}
