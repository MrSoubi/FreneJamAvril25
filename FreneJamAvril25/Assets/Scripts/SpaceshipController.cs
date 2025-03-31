using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 3f;

    void Update()
    {
        // Récupérer les entrées du clavier
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculer la direction du mouvement
        Vector3 moveDirection = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        // Déplacer le vaisseau
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Si le vaisseau se déplace, le faire tourner pour s'orienter dans la direction du mouvement
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
