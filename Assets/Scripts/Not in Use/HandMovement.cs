using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    //public HandType handType;

    public HandControl handControl;

    Rigidbody hand;
    [SerializeField] float force;

    void Start()
    {
        hand = GetComponent<Rigidbody>();
    }

    public void HandForce()
    {
        hand.AddForce(0f, force, 0f, ForceMode.Force);
    }
}
