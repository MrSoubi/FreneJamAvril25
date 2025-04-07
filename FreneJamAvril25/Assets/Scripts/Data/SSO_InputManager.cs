using UnityEngine;

public class SSO_InputManager : ScriptableObject
{
    public RSE_OnClick RSE_OnClick;
    public LayerMask layerMask;
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                hit.collider.GetComponent<IClickable>()?.OnClick();
                Debug.Log(hit.collider);
            }
        }
    }
}