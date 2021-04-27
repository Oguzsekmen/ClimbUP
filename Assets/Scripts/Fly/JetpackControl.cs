using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JetpackControl : MonoBehaviour
{
    public GameObject[] hands;
    public float flyTime = 10;    
    HandsMovementController handMovementController;

    [SerializeField]
    GameObject jetpack;
    float time;
    bool isBackJump = false;


    private void Start()
    {
        jetpack.SetActive(false);
        handMovementController = FindObjectOfType<HandsMovementController>();       
    }

    private void Update()
    {
        if (time > 0)
        {
            ActivateJetpack();
            time -= Time.deltaTime;
        }
        if (time <= 0)
        {
            InActivateJetpack();

        }
        if (time <=10 && time>= 9)
        {
            BackJump(-2f);
        }
        if (time <= 2 && time >= 1)
        {
            BackJump(2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Jetpack")
        {
            time = flyTime;
            Destroy(other.gameObject);
        }
    }

    void ActivateJetpack()
    {
        FlyControl.FlyStatu = true;
        jetpack.SetActive(true);
        Fly(5f);

    }

    void InActivateJetpack()
    {
        //BackJump(5f);
        FlyControl.FlyStatu = false;
        jetpack.SetActive(false);

    }

    void BackJump(float jumpDistance)
    {
        Vector3 leftHand = hands[0].transform.position + new Vector3(0f, 0f, jumpDistance);
        Vector3 righttHand = hands[1].transform.position + new Vector3(0f, 0f, jumpDistance);
        //Vector3 handMatcher = new Vector3(righttHand.x, leftHand.y, righttHand.z);

        hands[0].transform.DOMove(leftHand, 1f);
        hands[1].transform.DOMove(righttHand, 1f);
    }

    public void Fly(float y)
    {
        Vector3 leftHand = hands[0].transform.position + new Vector3(0f, y, 0f);
        Vector3 righttHand = hands[1].transform.position + new Vector3(0f, y, 0f);
        //Vector3 handMatcher = new Vector3(righttHand.x, leftHand.y, righttHand.z);

        hands[0].transform.DOMove(leftHand, 1f);
        hands[1].transform.DOMove(righttHand, 1f);
        HandsMovementController.isLeft = true;
    }
}
