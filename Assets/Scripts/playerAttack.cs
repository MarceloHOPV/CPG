using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public GameObject shoot;
    void Start()
    {
        
    }
    void Update()
    {
        attack();
    }
    void attack()
    {
        if(Input.GetKeyDown("e"))
        {
            if(transform.eulerAngles.y == 0)
            {
                Instantiate(shoot, new Vector3(transform.position.x+0.6f, transform.position.y,transform.position.z),transform.rotation);
            }
            else if(transform.eulerAngles.y == 180)
            {
                Instantiate(shoot, new Vector3(transform.position.x-0.6f, transform.position.y,transform.position.z),transform.rotation);
            }
            
        }
    }

    
}