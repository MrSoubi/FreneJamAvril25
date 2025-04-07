using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public LSO_SpaceshipController logic;

    private void Awake()
    {
        DSO_SpaceshipController newData = logic.data;
        logic = ScriptableObject.CreateInstance<LSO_SpaceshipController>();
        logic.data = newData;
        logic.Initialize(gameObject);
    }

    void Update()
    {
        logic.Update();
    }
}
