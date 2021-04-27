using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollisionHandler : MonoBehaviour
{
    SpringJoint springJoint;
    public float SpringForce
    {
        get
        {
            return springJoint.spring;
        }
        set
        {
            springJoint.spring = value;
        }
    }

    public float MinDistance
    {
        private get
        {
            return springJoint.minDistance;
        }
        set
        {
            springJoint.minDistance = value;
        }
    }

    private void Awake()
    {
        springJoint = GetComponent<SpringJoint>();
        SpringForce = springJoint.spring;
    }
}
