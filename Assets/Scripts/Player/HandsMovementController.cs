using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandsMovementController : MonoBehaviour
{
    GameManager gameManager;
    public HandControl handControl;
    [SerializeField] GameObject[] hands;
    public float moveTime = 1f;
    [SerializeField] float forceCoefficient = 1f;
    [SerializeField] float maxAllowedHandGap = 2.47f;
    public static bool isLeft = true;
    bool isMoving = false;
    [SerializeField]
    private float deneme;
    //Rigidbody[] handsBody = new Rigidbody[2];
    [SerializeField] float bodyForce = 5f;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void MoveHand(HandControl handType,float force, Vector3 position)
    {
        int i;
        if (handType == HandControl.LEFT) { i = 0; }
        else { i = 1; }
        Vector3 direction = (position - hands[i].transform.position).normalized;
        Vector3 target = hands[i].transform.position + (/*direction * force **/ forceCoefficient*Vector3.up /*/Time.timeScale*/);
        //DoDistanceCheck(i,target);
        hands[i].transform.DOMove(target, moveTime);
    }

    public void ClimbUp()
    {
        //int i = 0;
        //int j = 1;
        //if (isLeft) { i = 0; j = 1; }
        //else { i = 1; j = 0; }
        if (!isMoving && !FlyControl.FlyStatu && !GlassFall.glassFallCheck)
        {
            isMoving = true;
            Debug.Log("Clim up");
            int i = 0;
            int j = 1;
            if (isLeft) { i = 0; j = 1; }
            else { i = 1; j = 0; }
            StartCoroutine(DoingMovement());
            Vector3 target = hands[i].transform.position + (forceCoefficient * Vector3.up);
            Vector3 currentPos = hands[i].transform.position;
            Vector3 currentPosJ = hands[j].transform.position;
            Rigidbody handleRigidBodyI = hands[i].GetComponent<Rigidbody>();
            Rigidbody handleRigidBodyJ = hands[j].GetComponent<Rigidbody>();
            StartCoroutine(MoveHandle(handleRigidBodyI, handleRigidBodyJ, currentPos, target , currentPosJ));
            isLeft = !isLeft;
        }
    }

    IEnumerator MoveHandle(Rigidbody handBodyI, Rigidbody handBodyJ, Vector3 currentPos, Vector3 target,Vector3 oppositeHandPos)
    {
        Vector3 newTarget = target + new Vector3(0f, bodyForce, 0f);
        Vector3 oppositeHandTarget = oppositeHandPos + new Vector3(0f, bodyForce, 0f);
        float timer = 0f;
        while (timer <= 0.75f)
        {
            Vector3 position = Vector3.Lerp(currentPos, newTarget, timer / 0.75f);
            Vector3 oppositeHandPosition= Vector3.Lerp(oppositeHandPos, oppositeHandTarget, timer / 0.75f);
            timer += Time.fixedDeltaTime;
            handBodyI.MovePosition(position);
            handBodyJ.MovePosition(oppositeHandPosition);
            yield return null;
        }
        handBodyI.MovePosition(newTarget);
        handBodyJ.MovePosition(oppositeHandTarget);
    }

    IEnumerator DoingMovement()
    {
        isMoving = true;
        yield return new WaitForSeconds(deneme);
        isMoving = false;
    }
}
