using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotate : MonoBehaviour
{
    public GameObject apartment;
    RotateInput rotateInput;
    float rotateAngle;
    float rotateSpeed = 10f;
    bool isCooldownOn = false;

    private void Start()
    {
        rotateInput = FindObjectOfType<RotateInput>();
        string apartmentTag = apartment.tag;
        switch (apartmentTag)
        {
            case "four":
                rotateAngle = 90f;
                break;
            case "five":
                rotateAngle = 72;
                break;
            case "six":
                rotateAngle = 60;
                break;
            case "seven":
                rotateAngle = 52;
                break;
            case "eight":
                rotateAngle = 45f;
                break;
        }
    }

    private void Update()
    {
        RotateApartment();
    }

    void RotateApartment()
    {

        rotateInput.Swipe();
        if (isCooldownOn) { return; }
        if (rotateInput.direction == "left")
        {
            StartCoroutine(StartCooldown());
            apartment.transform.DORotate( new Vector3(0f, - rotateAngle, 0f) , 0.5f, RotateMode.WorldAxisAdd);
            rotateInput.direction = "none";
        }
        if (rotateInput.direction == "right")
        {
            StartCoroutine(StartCooldown());
            apartment.transform.DORotate(new Vector3(0f, rotateAngle, 0f), 0.5f, RotateMode.WorldAxisAdd);
            rotateInput.direction = "none";
        }
    }
    IEnumerator StartCooldown()
    {
        isCooldownOn = true;
        yield return new WaitForSeconds(0.5f);
        isCooldownOn = false;
    }
}
