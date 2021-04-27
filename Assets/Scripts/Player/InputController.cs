using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum HandControl
{
    LEFT,
    RIGHT
}
public class InputController : MonoBehaviour
{
    public HandControl HandCont;
    private float startTime;
    private float endTime;
    private float holdTimer = 0f;
    Vector3 mouseWorldPos;
    [SerializeField] LayerMask planeLayer;
    Ray ray;
    RaycastHit hitData;
    Camera mainCam;
    //[SerializeField] HandsMovementController[] handMovement;
    HandsMovementController handMovement;
    private bool isCooldownOn = false;
    [SerializeField] float moveTime = 1f;
    bool isPressed = false;

    private void Start()
    {
        handMovement = FindObjectOfType<HandsMovementController>();
        mainCam = Camera.main;
    }
        
    private void Update()
    {
        GetHoldTime();
    }

    void GetHoldTime()
    {
        //if (isCooldownOn) { return; }
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    isPressed = true;
        //    startTime = Time.time;
        //}
        //if (Input.GetButtonUp("Fire1"))
        //{
        //    if(!isPressed) { return; }
        //    isPressed = false;
        //    endTime = Time.time;
        //    holdTimer = endTime - startTime;
        //    //handMovement[(int)HandCont].HandForce();
        //    handMovement.MoveHand(HandCont, holdTimer,GetMousePosition());
        //    if (HandCont == HandControl.LEFT)
        //    {
        //        HandCont = HandControl.RIGHT;
        //    }
        //    else
        //    {
        //        HandCont = HandControl.LEFT;
        //    }
        //    StartCoroutine(ClimbCooldown());
        //}

        if (Input.GetButton("Fire1"))
        {
            handMovement.ClimbUp();
        }
    }

    private Vector3 GetMousePosition()
    {
        ray = mainCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitData, planeLayer, 1000))
        {
            mouseWorldPos = hitData.point;
        }
        return mouseWorldPos;
    }

    IEnumerator ClimbCooldown()
    {
        isCooldownOn = true;
        yield return new WaitForSeconds(moveTime);
        isCooldownOn = false;
    }
}
