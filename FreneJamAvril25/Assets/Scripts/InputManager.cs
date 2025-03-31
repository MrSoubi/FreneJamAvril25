using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public RSE_OnClick RSE_OnClick;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RSE_OnClick.Trigger?.Invoke();
        }
    }
}
