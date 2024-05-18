using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShooter : MonoBehaviour
{
    public GameObject Shooter;
    float time;
    public float StarTime;
    public bool Spawn = false;
    void Start()
    {
        time = StarTime;
    }
    private void Update()
    {
        if(!Spawn)
        {
            time -= Time.deltaTime;

            if(time<=0)
            {
                Instantiate(Shooter, transform.position, transform.rotation,transform);   
                time = StarTime;
                Spawn = true;
            }
        }
        if(transform.childCount == 0)
        {
            Spawn = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

}
