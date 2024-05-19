using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour
{
    public int rockC = 0;
    public Rigidbody2D rb;
    public void rockCount()
    {
        rockC += 1;
        if(rockC>= 3)
        {
            rb.velocity = new Vector3(0,-5,3) ;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("boss"))
        {
            Destroy(gameObject);
        }
    }
}
