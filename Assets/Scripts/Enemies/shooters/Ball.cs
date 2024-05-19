using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private float time;

    public playerLife player;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //player = FindObjectOfType<PlayerHealth>();

        // Verifica a escala do canh�o para determinar a dire��o da bola
        
        if(transform.rotation.y == 0)  // Canh�o est� virado para a esquerda
        {
            // Acelera a bola para a esquerda
            rb.velocity = new Vector2(-1f * speed,rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(1f * speed,rb.velocity.y);
        }

        // Inicia a contagem regressiva para destruir a bola ap�s 2 segundos
        StartCoroutine(DestroyAfterDelay(time));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<playerLife>();
            player.takeDamage(damage);
            Destroy(gameObject); // Destroi a bola ao colidir com o jogador
        }

        if (other.CompareTag("chao"))
        {
            Destroy(gameObject); // Destroi a bola ao colidir com o jogador
        }

        if(other.CompareTag("tree"))
        {
            other.GetComponent<tree>().perderVida(damage);
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject); // Destroi a bola ap�s o atraso especificado
    }
}