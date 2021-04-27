using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFixer : MonoBehaviour
{
    public void FixAngleAnim()
    {
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }
}
