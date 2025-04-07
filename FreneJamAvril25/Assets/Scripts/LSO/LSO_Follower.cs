using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CreateAssetMenu(fileName = "LSO_Follower", menuName = "LSO/Follower")]
public class LSO_Follower : LogicScriptableObject
{
    public DSO_Follower data;

    public override void Initialize(GameObject owner)
    {
        base.Initialize(owner);

        DSO_Follower newData = ScriptableObject.CreateInstance< DSO_Follower >();
        newData.target = data.target;
        newData.damping = data.damping;
        data = newData;
    }

    public void Update()
    {
        Vector3 targetPosition = new Vector3(data.target.transform.position.x, owner.transform.position.y, data.target.transform.position.z);
        owner.transform.position = Vector3.Lerp(owner.transform.position, targetPosition, data.damping * Time.deltaTime);
    }
}