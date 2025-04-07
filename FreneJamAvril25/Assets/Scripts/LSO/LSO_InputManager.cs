using UnityEngine;

[CreateAssetMenu(fileName = "LSO_InputManager", menuName = "LSO/InputManager")]
public class LSO_InputManager : LogicScriptableObject
{
    public DSO_InputManager data;

    public override void Initialize(GameObject owner)
    {
        base.Initialize(owner);

        DSO_InputManager newData = ScriptableObject.CreateInstance<DSO_InputManager>();
        newData.RSE_OnClick = data.RSE_OnClick;
        newData.layerMask = data.layerMask;
        data = newData;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, data.layerMask))
            {
                hit.collider.GetComponent<IClickable>()?.OnClick();
                Debug.Log(hit.collider);
            }
        }
    }
}