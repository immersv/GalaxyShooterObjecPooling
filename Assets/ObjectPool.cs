﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class PrefabPool
    {
        public GameObject prefabName;
        public int number;
        public bool expandable;
    }

    public static ObjectPool singleTon;//singleton class
    public List<PrefabPool> items;// opool list
    public List<GameObject> poolItems;//gameobjects list in pool
    private void Awake()
    {
        singleTon = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        poolItems = new List<GameObject>();
        foreach (PrefabPool item in items)
        {
            for (int i = 0; i < item.number; i++)
            {
                GameObject obj = Instantiate(item.prefabName);
                obj.SetActive(false);
                poolItems.Add(obj);
            }

        }

    }
    public GameObject GetSpawnObj(string tagName)
    {
        for (int i = 0; i < poolItems.Count; i++)
        {
            if (!poolItems[i].activeInHierarchy && poolItems[i].tag == tagName)
            {
                return poolItems[i];
            }
        }
        foreach (PrefabPool item in items)
        {
            if (item.prefabName.tag == tagName && item.expandable)
            {
                GameObject tagobj = Instantiate(item.prefabName);
                tagobj.SetActive(false);
                poolItems.Add(tagobj);
                return tagobj;
            }

        }
        return null;
    }
   
}
