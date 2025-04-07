using UnityEngine;

[CreateAssetMenu(fileName = "LSO_SpaceshipController", menuName = "LSO/SpaceshipController")]
public class LSO_SpaceshipController : LogicScriptableObject
{
    public DSO_SpaceshipController data;

    public override void Initialize(GameObject owner)
    {
        base.Initialize(owner);

        DSO_SpaceshipController newData = ScriptableObject.CreateInstance<DSO_SpaceshipController>();
        newData.moveSpeed = data.moveSpeed;
        newData.rotationSpeed = data.rotationSpeed;
        data = newData;
    }

    public void Update()
    {
        // Récupérer les entrées du clavier
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculer la direction du mouvement
        Vector3 moveDirection = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        // Déplacer le vaisseau
        owner.transform.position += moveDirection * data.moveSpeed * Time.deltaTime;

        // Si le vaisseau se déplace, le faire tourner pour s'orienter dans la direction du mouvement
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, targetRotation, data.rotationSpeed * Time.deltaTime);
        }
    }
}