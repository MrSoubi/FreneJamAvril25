using UnityEngine;

public class CargoBehavior : MonoBehaviour
{
    public LSO_Cargo logic;

    private void OnEnable()
    {
        logic.Enable();
    }

    private void OnDisable()
    {
        logic.Disable();
    }

    public void AddStock(int amount)
    {
        logic.AddStock(amount);
    }
}
