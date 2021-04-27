using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSpawner : MonoBehaviour
{
    
    [SerializeField]
    Transform buildContainer;
    
    public static GameObject[] buildObjects;

    public static int numSpawned = 0;
    [SerializeField]
    int buildnumber;

    void Start()
    {
        buildObjects = Resources.LoadAll<GameObject>("Prefabs");
    }

    public void Spawn()
    {
        int whichItem = Random.Range (0, 4);
        
        GameObject build = Instantiate (buildObjects[whichItem]) as GameObject;

        
        if(numSpawned == 0)
        {
            Debug.Log(buildContainer.position);
            build.transform.position = buildContainer.position;
        }
        else
        {
            build.transform.position = new Vector3(buildContainer.position.x,numSpawned * 5.40f,buildContainer.position.z);
            build.transform.rotation = Quaternion.Euler(new Vector3(0, numSpawned * 45, 0));
            
        }   
        
        numSpawned++;
        
    }

    void Update()
    {
        if(buildnumber > numSpawned)
        {
            
            Spawn();
        }
    }
}
