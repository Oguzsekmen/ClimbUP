using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttantionCheck : MonoBehaviour
{
    UIManager uiManager;    

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            uiManager.AttantionImageTrue();           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            uiManager.AttentionImageFalse();            
        }
    }
}
