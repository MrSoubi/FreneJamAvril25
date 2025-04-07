using UnityEngine;

public class FollowerBehavior : MonoBehaviour
{
    public LSO_Follower logic;
    public GameObject target;
    public float damping;
    public Vector3 offset;
    private void Update()
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, offset.y, target.transform.position.z + offset.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
    }
}
