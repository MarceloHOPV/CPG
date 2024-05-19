using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss : MonoBehaviour
{
    public GameObject FireShoot;
    public GameObject aim;

    public float timeBetween;
    public float StartTimeBetween;

    void Start() 
    {
        timeBetween = StartTimeBetween;
        aim = GameObject.Find("aim");
    } 
    void Update()
    {
        timeBetween -= Time.deltaTime;
        if(timeBetween <= 0)
        {
            Shoot();
            timeBetween = StartTimeBetween;
        }
        
    }

    void Shoot()
    {
        Instantiate(FireShoot, aim.transform.position, aim.transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("rock"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        }
    }
}
