using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHand : MonoBehaviour
{
    public float force = 100f;
    Rigidbody leftHand;
    HandControl handControl;

    private void Start()
    {
        leftHand = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (handControl == HandControl.LEFT )
        {
            leftHand.AddForce(0f, force, 0f, ForceMode.Force);
        }
    }
}
