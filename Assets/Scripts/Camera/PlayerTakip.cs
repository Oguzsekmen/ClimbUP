using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakip : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public float speed = 0.125f;

    [SerializeField]
    Vector3 offset;

    private void Start()
    {
        transform.position = enemy.transform.position + offset;
    }

    void FixedUpdate()
    {
        if (Pavement.isGameStarted)
        {
            Vector3 position = player.transform.position + offset;
            Vector3 lerp = Vector3.Lerp(transform.position, position, speed * 5 * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, lerp.y, lerp.z);
            
        }
        
    }
}
