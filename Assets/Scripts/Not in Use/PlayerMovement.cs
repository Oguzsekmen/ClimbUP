using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum HandControl
//{
//    LEFT,
//    RIGHT
//}

public class PlayerMovement : MonoBehaviour
{
    public HandControl HandCont;
    private float startTime;
    private float endTime;
    private float holdTimer = 0f;
    [SerializeField] HandMovement[] handMovement;


    private void Update()
    {
        GetHoldTime();
    }
    
    void GetHoldTime()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            startTime = Time.time;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            endTime = Time.time;
            holdTimer = endTime - startTime;
            handMovement[(int)HandCont].HandForce();

            if (HandCont == HandControl.LEFT)
            {
                HandCont = HandControl.RIGHT;
            }
            else
            {
                HandCont = HandControl.LEFT;
            }
        }
    }
}
