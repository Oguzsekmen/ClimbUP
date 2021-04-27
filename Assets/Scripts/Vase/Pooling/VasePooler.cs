using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VasePooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject vase;
        public int objectSize;
    }

    #region Singleton
    public static VasePooler Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictinary;

    private void Start()
    {
        poolDictinary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.objectSize; i++)
            {
                GameObject obj = Instantiate(pool.vase);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictinary.Add(pool.tag, objectPool);
        }
    }


    public GameObject SpawnFromPool(string tag, Vector3 pos, Quaternion rotation)
    {
        if (!poolDictinary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + "doesn't exist");
            return null;
        }


        GameObject objectToSpawn = poolDictinary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = pos;
        objectToSpawn.transform.rotation = rotation;

        //IVase vase = objectToSpawn.GetComponent<IVase>();

        //if (vase !=null)
        //{
        //    vase.VaseFall();
        //}

        poolDictinary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
