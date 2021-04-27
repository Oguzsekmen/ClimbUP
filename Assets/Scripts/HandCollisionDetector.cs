using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollisionDetector : MonoBehaviour
{
    GameManager gameManager;
    float moveTime;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        moveTime = FindObjectOfType<HandsMovementController>().moveTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "trap")
        {
            StartCoroutine(GameLostDelay());
        }
    }
    IEnumerator GameLostDelay()
    {
        yield return new WaitForSeconds(moveTime);
        gameManager.IsGameLost = true;
        Debug.Log("Trap collision");
    }
}
