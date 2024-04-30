using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
    public InputActionProperty pinchAction;


    void Start()
    {
        FindPinchActionInChildren(transform);
    }

    private void FindPinchActionInChildren(Transform parent)
    {
        if (pinchAction != null)
            return; // If already found, no need to search further

        pinchAction = parent.GetComponentInChildren<InputActionProperty>();
    }
}