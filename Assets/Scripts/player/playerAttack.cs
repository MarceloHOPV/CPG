using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public GameObject shoot;
    public PlayerAnimation pa;
<<<<<<< HEAD
    void Start()
=======
    private void Awake()
>>>>>>> 82ee1ddba0142d1a14e5b76db323d3651061765e
    {
        pa = GetComponent<PlayerAnimation>();
    }
    void Update()
    {
        attack();
    }
    void attack()
    {
        if(Input.GetKeyDown("e"))
        {
            pa.PlayAnimation("PlayerAtack");
<<<<<<< HEAD

            if (transform.eulerAngles.y == 0)
=======
            
        }
    }
    void spawnShoot()
    {
        if (transform.eulerAngles.y == 0)
>>>>>>> 82ee1ddba0142d1a14e5b76db323d3651061765e
            {
                Instantiate(shoot, new Vector3(transform.position.x+0.6f, transform.position.y,transform.position.z),transform.rotation);
            }
            else if(transform.eulerAngles.y == 180)
            {
                Instantiate(shoot, new Vector3(transform.position.x-0.6f, transform.position.y,transform.position.z),transform.rotation);
            }
<<<<<<< HEAD
            
        }
=======
>>>>>>> 82ee1ddba0142d1a14e5b76db323d3651061765e
    }

    
}
