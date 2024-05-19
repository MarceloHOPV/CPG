using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{

    public GameObject enemy;
    float time;
    public float StarTime;
    void Start()
    {
        time = StarTime;
    }
    private void Update()
    {
        time -= Time.deltaTime;

        if(time<=0)
        {
            Instantiate(enemy, transform.position, transform.rotation);   
            GameObject.FindWithTag("BossSpawn").GetComponent<bossSpawn>().Contador();
            time = StarTime;
        }

        
    }
 

    


}
