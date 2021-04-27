using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerForFinalAnimations : MonoBehaviour
{

    public Rigidbody sousage;
    public Rigidbody thief;
    public Animator animForSouage;
    public Animator animForThief;
    public GameObject vakums;
    Finish finish;
    Rigidbody[] bodies;
    bool isGameEnd = false;
    [SerializeField]
    ParticleSystem boom;


    private void Awake()
    {
        bodies = GetComponentsInChildren<Rigidbody>();
        finish = FindObjectOfType<Finish>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="FinalCollider" && !isGameEnd)
        {
            isGameEnd = true;
            
            HandCollisionHandler[] handCollisionHandlers = FindObjectsOfType<HandCollisionHandler>();

            foreach (HandCollisionHandler element in handCollisionHandlers)
            {
                element.MinDistance = Mathf.Infinity;
            }
            foreach (Rigidbody element in bodies)
            {
                element.isKinematic = true;
                element.collisionDetectionMode = CollisionDetectionMode.Discrete;
            }
            Rigidbody body = GetComponent<Rigidbody>();
            body.isKinematic = true;
            body.collisionDetectionMode = CollisionDetectionMode.Discrete;
            
            //transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            transform.position = FindObjectOfType<GameEndPosition>().gameObject.transform.position;
            animForSouage.enabled = true;
            animForSouage.Play("FinalClimb");
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            StartCoroutine(NextLevelScreen());
        }
    }

    void Update()
    {
        /*if (animForSouage.GetCurrentAnimatorStateInfo(0).IsName("JumpOn"))
        {
            thief.transform.rotation = Quaternion.Euler(0, 80, 0);
        }*/

        if (animForSouage.GetCurrentAnimatorStateInfo(0).IsName("JumpOn"))
        {
            sousage.transform.rotation = Quaternion.Euler(0, -90, 0);
            animForThief.SetBool("readyToFight", true);
            boom.Play();
        }

        if (boom.IsAlive(true))
        {
            //thief.useGravity = true;
            Invoke("ScaleCharacter", 2.0f);
        }
        
    }

    void ScaleCharacter()
    {
        sousage.transform.rotation = Quaternion.Euler(0, 180, 0);
    }
    IEnumerator NextLevelScreen()
    {
        yield return new WaitForSecondsRealtime(10f);
        finish.NextLevel();
    }
}
