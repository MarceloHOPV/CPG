using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public GameObject shoot;
    public PlayerAnimation pa;
    public bool atacando;

    private void Awake()
    {
        pa = GetComponent<PlayerAnimation>();
        atacando = false;
    }
    void Update()
    {
        attack();
    }
    void attack()
    {
        if(Input.GetKeyDown("e") && !atacando)
        {
            pa.PlayAnimation("PlayerAtack");

            
        }
    }

    public void setAttack()
    {
        if(!atacando)
            atacando = true;
        else if(atacando)
            atacando = false;
    }

    void spawnShoot()
    {
        if (transform.eulerAngles.y == 0)

            {
                Instantiate(shoot, new Vector3(transform.position.x+0.6f, transform.position.y,transform.position.z),transform.rotation);
            }
            else if(transform.eulerAngles.y == 180)
            {
                Instantiate(shoot, new Vector3(transform.position.x-0.6f, transform.position.y,transform.position.z),transform.rotation);
            }
    }

    
}
