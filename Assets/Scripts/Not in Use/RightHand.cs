using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHand : MonoBehaviour
{
    public float force = 100f;
    Rigidbody rightHand;
    HandControl handControl;

    private void Start()
    {
        rightHand = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (handControl == HandControl.RIGHT)
        {
            rightHand.AddForce(0f, force, 0f, ForceMode.Force);
        }
    }
}
