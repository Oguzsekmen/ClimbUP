using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    Rigidbody[] bodies;
    [SerializeField] GameObject dummy;
    MeshCollider[] colliders;   
    // Start is called before the first frame update
    void Awake()
    {
        bodies = GetComponentsInChildren<Rigidbody>();
        colliders = GetComponentsInChildren<MeshCollider>();
        foreach (Rigidbody element in bodies)
        {
            element.useGravity = false;
        }
        foreach (MeshCollider element in colliders)
        {
            element.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !FlyControl.FlyStatu)
        {
            FindObjectOfType<GameManager>().IsGameLost = true;
            // GAME OVER
            
            Destroy(this.GetComponent<BoxCollider>());            
            foreach (Rigidbody element in bodies)
            {
                element.useGravity = true;
            }
            foreach (MeshCollider element in colliders)
            {
                element.enabled = true;
            }
            dummy.SetActive(true);
        }
    }

}
