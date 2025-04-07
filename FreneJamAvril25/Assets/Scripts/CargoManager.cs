using UnityEngine;

public class CargoManager : MonoBehaviour
{
    public RSE_OnResourceCollected RSE_OnResourceCollected;

    public int maxStock = 100;
    public int currentStock = 0;

    private void OnEnable()
    {
        RSE_OnResourceCollected.Trigger += AddStock;
    }

    public void AddStock(int amount)
    {
        currentStock += amount;
        if (currentStock > maxStock)
        {
            currentStock = maxStock;
        }

        Debug.Log("Current stock: " + currentStock);
    }
}
