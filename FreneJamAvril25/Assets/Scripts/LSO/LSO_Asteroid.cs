using UnityEngine;

[CreateAssetMenu(fileName = "LSO_Asteroid", menuName = "LSO/Asteroid")]
public class LSO_Asteroid : LogicScriptableObject
{
    public DSO_Asteroid data;

    public override void Initialize(GameObject owner)
    {
        base.Initialize(owner);

        DSO_Asteroid newData = ScriptableObject.CreateInstance<DSO_Asteroid>();
        newData.OnClick = data.OnClick;
        newData.OnAsteroidClicked = data.OnAsteroidClicked;
        newData.collectiblePrefab = data.collectiblePrefab;
        newData.stock = data.stock;
        newData.health = data.health;
        data = newData;
    }

    public void OnClick()
    {
        data.OnAsteroidClicked.Trigger(owner);
    }

    public void TakeDamage(int damage)
    {
        data.health -= damage;

        if (data.health <= 0)
        {
            Destroy(owner);
        }
    }

    public void Destroy()
    {
        for (int i = 0; i < data.stock; i++)
        {
            Vector3 spawnPosition = new Vector3(owner.transform.position.x + Random.Range(-10f, 10f), owner.transform.position.y, owner.transform.position.z + Random.Range(-10f, 10f));
            var collectible = Instantiate(data.collectiblePrefab, spawnPosition, Quaternion.identity);
            collectible.GetComponent<Rigidbody>().AddForce((collectible.transform.position - owner.transform.position) * 100);

            collectible.transform.rotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
            collectible.GetComponent<Rigidbody>().AddTorque(Random.insideUnitSphere * 100);
        }
    }
}
