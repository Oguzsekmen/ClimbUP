using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vakum : MonoBehaviour
{
    public GameObject hand;
    [Range(0f,100f)] public float power;

    void FixedUpdate()
    {

        Vector3 lerpPosition = Vector3.Lerp(transform.position, hand.transform.position, power * Time.fixedDeltaTime);
        transform.position = lerpPosition;
    }
}
