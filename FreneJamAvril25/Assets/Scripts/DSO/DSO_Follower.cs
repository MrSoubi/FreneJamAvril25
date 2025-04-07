using UnityEngine;

[CreateAssetMenu(fileName = "DSO_Follower", menuName = "DSO/Follower")]
public class DSO_Follower : DataScriptableObject<FollowerBehavior>
{
    public GameObject target;
    public float damping = 1f;
}