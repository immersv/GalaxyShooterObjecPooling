using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstreiodSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100) < 5)
        {
            GameObject asteroidObj = ObjectPool.singleTon.GetSpawnObj("Asteroid");
            if (asteroidObj != null)
            {
                asteroidObj.transform.position = this.transform.position + new Vector3(Random.Range(-2.6f,2.6f), 0, 0);
                asteroidObj.SetActive(true);
            }
           

        }
        
    }
}
