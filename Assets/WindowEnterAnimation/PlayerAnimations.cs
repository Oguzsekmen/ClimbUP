using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PlayerAnimations : MonoBehaviour
{
    private Animator anim;
    Rigidbody[] bodies;
    Rigidbody body;

    public GameObject player1;

    GameObject collidingObject;

    public GameObject apartment;

    bool isrotated = true;
    bool oynadı = true;
    bool isInside = false;
    bool isAnimEnded = false;
    Transform enterPortal;
    bool isPortalCooldownOn = false;
    bool dummy = true;
    private void Awake()
    {
        bodies = GetComponentsInChildren<Rigidbody>();
        body = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        //collidingObject = null;
    }   

    private void Update()
    {
        
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("ExitAnimations") && !isAnimEnded)
        {
            isAnimEnded = true;
            Debug.Log("exit portal");
            Debug.Log("exit");
            StartRagdollStyleClimbing();
        }
        if (isInside&isrotated)
        {
            anim.enabled = false;
            //apartment.transform.DORotate(new Vector3(0f, 45f, 0f), 2f, RotateMode.LocalAxisAdd);
            float seconds = Mathf.Abs(GetAngleDiff()) / 45f;
            apartment.transform.DORotate(new Vector3(0f, GetAngleDiff(), 0f), seconds , RotateMode.LocalAxisAdd);
            isPortalCooldownOn = true;
            StartCoroutine(ExitPortal(seconds));

            isrotated = false;
            //Invoke("Check",2.1f);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Finish")&oynadı)
        {
            //Debug.Log(gameObject.transform.position.z);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            isInside = true;
            oynadı = false;
        }

    }

    private float GetAngleDiff()
    {
        float angleDiff = GetExitPortal().transform.eulerAngles.y - enterPortal.eulerAngles.y;
        Debug.Log(angleDiff);
        return angleDiff;
    }

    private Transform GetExitPortal()
    {
        int siblingIndex = 0;
        int childIndex = enterPortal.GetSiblingIndex();
        if (childIndex == 0) { siblingIndex = 1; }
        Transform exitPortal = enterPortal.parent.transform.GetChild(siblingIndex);
        return exitPortal;
    }

    IEnumerator ExitPortal(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        collidingObject = GetExitPortal().gameObject;
        StartCoroutine(PortalCooldownTimer());
        transform.position = collidingObject.transform.GetChild(1).transform.position;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 3f);
        anim.applyRootMotion = false;
        anim.enabled = true;
        player1.transform.rotation = Quaternion.Euler(0, 180, 0);
        anim.Play("RollContinue");
        isInside = false;
    }

    IEnumerator PortalCooldownTimer()
    {
        yield return new WaitForSeconds(15f);
        isPortalCooldownOn = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Block") && !isPortalCooldownOn && !FlyControl.FlyStatu )
        {
            //Physics.IgnoreLayerCollision(8, 9);
            //Physics.IgnoreLayerCollision(0, 9);
            //Physics.IgnoreLayerCollision(9, 9);
            HandCollisionHandler[] handCollisionHandlers = FindObjectsOfType<HandCollisionHandler>();
            foreach (Rigidbody element in bodies)
            {
                element.isKinematic = true;
                //element.Sleep();
            }
            foreach (HandCollisionHandler element in handCollisionHandlers)
            {
                element.MinDistance = Mathf.Infinity;
            }
            body.isKinematic = true;
            //body.Sleep();
            Debug.Log("portal giriş");
            enterPortal = other.gameObject.transform;
            isAnimEnded = false;
            anim.enabled = true;
            transform.position = other.transform.GetChild(0).transform.position;
            foreach (Rigidbody body in bodies)
            {
                body.transform.Rotate(0, 0, 0);
            }
            //HandCollisionHandler[] handCollisionHandlers = FindObjectsOfType<HandCollisionHandler>();

            anim.SetBool("isColliding", true);
            gameObject.GetComponent<FallControl>().enabled = false;


            player1.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        //if (other.gameObject.CompareTag("ExitBlock") && isInside) 
        //{
        //    collidingObject = other.gameObject;
        //    Debug.Log(other.gameObject.transform.localRotation.eulerAngles.z);
        //    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 3f);

        //    anim.applyRootMotion = false;
        //    anim.enabled = true;
        //    player1.transform.rotation = Quaternion.Euler(0, 180, 0);
        //    anim.Play("RollContinue");
        //    isInside = false;
        //}
    }
    //void Check()
    //{
    //    if (collidingObject==null || !collidingObject.gameObject.CompareTag("ExitBlock"))
    //    {
    //        isrotated = true;
    //    }
    //}
    void StartRagdollStyleClimbing()
    {
        anim.enabled = false;
        HandCollisionHandler[] handCollisionHandlers = FindObjectsOfType<HandCollisionHandler>();
        StartCoroutine(TightenSpring(handCollisionHandlers));
    }

    IEnumerator TightenSpring(HandCollisionHandler[] springObjects)
    {
        foreach (Rigidbody element in bodies)
        {
            element.isKinematic = false;
            element.WakeUp();
        }
        body.isKinematic = false;
        float initialSpringForce = springObjects[0].SpringForce;
        float timer = 0f;
        while(timer < 3f)
        {
            foreach (HandCollisionHandler element in springObjects)
            {
                element.MinDistance = 0.1f;
            }
            timer += Time.unscaledDeltaTime;
            springObjects[0].SpringForce = Mathf.Lerp(0f, initialSpringForce, timer / 3f); ;
            springObjects[1].SpringForce = Mathf.Lerp(0f, initialSpringForce, timer / 3f); ;
            //Debug.Log(timer);
            yield return null;
        }
        Debug.Log("final");
        springObjects[0].SpringForce = initialSpringForce;
        springObjects[1].SpringForce = initialSpringForce;
        //Physics.IgnoreLayerCollision(8, 9,false);
        //Physics.IgnoreLayerCollision(0, 9, false);
        //Physics.IgnoreLayerCollision(9, 9, false);
        gameObject.GetComponent<FallControl>().enabled = true;



    }
}

