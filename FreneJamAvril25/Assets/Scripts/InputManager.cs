using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public RSE_OnClick RSE_OnClick;
    public LayerMask layerMask;
    void Update()
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
