using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public float direcao;
    public float speed;
    public Rigidbody2D rb;
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        if(transform.eulerAngles.y == 180)
        {
            direcao = -1f;
        }
        else
        {
            direcao = 1f;
        }
    }

    void Update()
    {
        rb.velocity = new Vector2(direcao * speed, rb.velocity.y);
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("chao"))
        {
            Destroy(gameObject);
        }
        else if(other.CompareTag("Shooter"))
        {
            other.GetComponent<Shooter>().PerdeVida(2);
            Destroy(gameObject);
        }
        else if(other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().perdeVida(2);
            Destroy(gameObject);
        }
    }
}
