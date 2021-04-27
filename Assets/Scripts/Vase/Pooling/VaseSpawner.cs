using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseSpawner : MonoBehaviour
{
    VasePooler vasePooler;
    GameObject player;

    float timer;
    public static bool isSpawned;
    bool isInside = false;
    public Animator animator;
    private void Start()
    {
        vasePooler = VasePooler.Instance;
        player = GameObject.FindGameObjectWithTag("Root");      
    }
    private void Update()
    {
        if (Mathf.Abs(player.transform.position.y - transform.position.y) < 35f)
        {
            isInside = true;
            
        }
        else
        {
            //animator.SetBool("Running", false);
        }
    }



    //private void FixedUpdate()
    //{
    //    if (Pavement.isGameStarted)
    //    {
    //        timer += Time.deltaTime;
    //        if (timer >= 5f)
    //        {

    //            Spawn();
    //            timer = 0f;
    //        }
    //        else
    //        {
    //            isSpawned = false;
    //        }
    //    }

    //}

    void Spawn()
    {
        isSpawned = true;
        GameObject go = vasePooler.SpawnFromPool("Vase", transform.position, Quaternion.identity) as GameObject;
        go.transform.parent = transform;


    }
    private void FixedUpdate()
    {
        if (Pavement.isGameStarted)
        {

            timer += Time.deltaTime;
            if (timer >= 7f && isInside && !FlyControl.FlyStatu)
            {
                Spawn();
                timer = 0f;
                animator.SetBool("Running", true);
            }
            else
            {
                animator.SetBool("Running", false);
            }
        }

    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        isInside = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        isInside = false;
    //    }
    //}
}
