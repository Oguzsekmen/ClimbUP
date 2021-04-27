using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [Space]
    [SerializeField]
    Transform buildContainer;

    BuildSpawner buildSpawner;

    private void Awake()
    {
        //buildSpawner = new BuildSpawner(buildContainer);
    }
}
