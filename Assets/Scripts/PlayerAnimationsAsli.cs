using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsAsli : MonoBehaviour
{
    private Animator anim;
    Rigidbody[] bodies;

    public GameObject player1;

    private void Awake()
    {
        bodies = GetComponentsInChildren<Rigidbody>();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Finish"))
        {
            player1.transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.Play("RollContinue");
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("ExitAnimations"))
        {
            StartRagdollStyleClimbing();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {

            anim.enabled = true;

            foreach (Rigidbody body in bodies)
            {
                body.transform.Rotate(0, 0, 0);
            }

            HandCollisionHandler[] handCollisionHandlers = FindObjectsOfType<HandCollisionHandler>();

            anim.SetBool("isColliding", true);

            foreach (HandCollisionHandler element in handCollisionHandlers)
            {
                element.MinDistance = Mathf.Infinity;
            }
            foreach (Rigidbody element in bodies)
            {
                element.isKinematic = true;
            }
        }
    }

    void StartRagdollStyleClimbing()
    {
        anim.enabled = false;

        HandCollisionHandler[] handCollisionHandlers = FindObjectsOfType<HandCollisionHandler>();

        foreach (HandCollisionHandler element in handCollisionHandlers)
        {
            element.MinDistance = 0f;
        }
        foreach (Rigidbody element in bodies)
        {
            element.isKinematic = false;
        }

    }
}

