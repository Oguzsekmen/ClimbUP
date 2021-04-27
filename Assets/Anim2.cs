using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim2 : MonoBehaviour
{
    public Rigidbody rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        bool isDone = anim.GetBool("isDone");

      

    }
}
