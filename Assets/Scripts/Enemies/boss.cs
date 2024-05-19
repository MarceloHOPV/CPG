using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossScript : MonoBehaviour
{
    public GameObject FireShoot;
    public GameObject aim;

    void Start() 
    {
        aim = GameObject.Find("aim");
    } 

    void Shoot()
    {
        Instantiate(FireShoot, aim.transform.position, aim.transform.rotation);
    }
}
