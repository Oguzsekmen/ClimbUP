using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInput : MonoBehaviour
{
    float firstPos;
    float lastPos;
    float swipeDirection;
    [HideInInspector] public string direction = "none";

    public void Swipe()
    {
#if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            firstPos = Input.mousePosition.x;
        }
        if (Input.GetMouseButtonUp(0))
        {
            lastPos = Input.mousePosition.x;

            swipeDirection = lastPos - firstPos;

            if (swipeDirection < -50f)
            {
                direction = "left";
            }
            else if (swipeDirection > 50f)
            {
                direction = "right";
            }
            else
            {
                direction = "none";
            }
        }

#elif UNITY_ANDROID || UNITY_IOS

        if (Input.touches.Length > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                firstPos = touch.position.x;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                lastPos = touch.position.x;
                swipeDirection = lastPos - firstPos;

                if (swipeDirection < -50f)
                {
                    direction = "left";
                }
                else if (swipeDirection > 50f)
                {
                    direction = "right";
                }
                else
                {
                    direction = "none";
                }
            }
        }
#endif



    }
}

