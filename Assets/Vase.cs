using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Vase : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ParticleSystem particleFX;
    MeshRenderer meshrenderer;
    Rigidbody body;
    BoxCollider boxCollider;    
    void Awake()
    {       
        meshrenderer = GetComponent<MeshRenderer>();
        body = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            meshrenderer.enabled = false;
            boxCollider.enabled = false;
            body.isKinematic = true;
            particleFX.Play();
            Destroy(gameObject, 3f);
        }
    }
   
}
