using UnityEngine;

public class AsteroidBehavior : MonoBehaviour, IClickable
{
    public LSO_Asteroid logic;
    private void Awake()
    {
        DSO_Asteroid newLogic = logic.data;
        logic = ScriptableObject.CreateInstance<LSO_Asteroid>();
        logic.data = newLogic;
        logic.Initialize(gameObject);
    }

    public void OnClick()
    {
        logic.OnClick();
    }

    public void TakeDamage(int damage)
    {
        logic.TakeDamage(damage);
    }

    private void OnDestroy()
    {
        logic.Destroy();
    }
}

public interface IClickable
{
    void OnClick();
}