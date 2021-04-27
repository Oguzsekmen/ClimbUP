using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassFall : MonoBehaviour
{
    FallControl fallControl;
    [SerializeField]
    float fallDistance = 5000f;
    public static bool glassFallCheck;

    private void Awake()
    {
        fallControl = FindObjectOfType<FallControl>();
        glassFallCheck = false;
    }

    private void Update()
    {
        if (glassFallCheck)
        {
            StartCoroutine(MakeFalse());
        }
    }

    IEnumerator MakeFalse()
    {
        yield return new WaitForSeconds(1.1f);
        glassFallCheck = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fallControl.SlideFall(fallDistance);
            glassFallCheck = true;
            Destroy(gameObject, 3f);
        }
    }
}
