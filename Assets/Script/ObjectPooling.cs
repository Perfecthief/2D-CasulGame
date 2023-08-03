using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling 
{
    private static ObjectPooling instance;

    public static ObjectPooling Instance
    {
        get
        {
            if (instance == null)
                instance = new ObjectPooling();
            return instance;
        }
    }

    private List<PoolObject> pool;
    private GameObject prefab;
    private Transform parentTransform;

    private ObjectPooling()
    {
        pool = new List<PoolObject>();
    }


    public void Initialize(GameObject prefab = null, int initialSize = 1)
    {
        if (this.prefab != null)
        {
            this.prefab = prefab;
            for (int i = 0; i < initialSize; i++)
            {
                CreateObject();
            }
        }
        else
            Debug.Log("prefab is none or null");
    }

    private PoolObject CreateObject()
    {
        GameObject obj = GameObject.Instantiate(prefab, parentTransform);
        obj.SetActive(false);
        PoolObject poolObject = new PoolObject { gameObject = obj, isActive = false };
        pool.Add(poolObject);
        return poolObject;
    }


}
