using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pavement : MonoBehaviour
{
    BoxCollider boxCollider;
    public float colliderWait = 5f;
    public static bool isGameStarted = false;


    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;
        
    }
   
    IEnumerator WaitForCollider()
    {
        yield return new WaitForSeconds(colliderWait);
        boxCollider.enabled = true;
    }

    private void Update()
    {
        if (isGameStarted)
        {
            StartCoroutine(WaitForCollider());
        }
        if (!isGameStarted)
        {
            boxCollider.enabled = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameManager>().IsGameLost = true;
        }
    }
}
