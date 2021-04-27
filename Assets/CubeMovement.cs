using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    Rigidbody body;
    [SerializeField] float force;
    public enum HandType {LeftHand , RightHand};
    [SerializeField] HandType handType;
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && handType == HandType.LeftHand)
        {
            body.AddForce(0f, force, 0f, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.RightArrow) && handType == HandType.RightHand)
        {
            body.AddForce(0f, force, 0f, ForceMode.Force);
        }
    }
}
