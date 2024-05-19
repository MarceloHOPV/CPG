using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSpawn : MonoBehaviour
{
    public int cont;
    GameObject[] spawns;
    GameObject spawn;
    void Start()
    {
        cont = 0;
    }
    public void Contador()
    {
        cont += 1;
        if(cont >= 20)
        {
            spawns = GameObject.FindGameObjectsWithTag("spawn");
            foreach (GameObject spawn in spawns)
            {
                Destroy(spawn);        
            }

        }
    }
}
