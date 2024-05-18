using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private Shooter trap;
    [SerializeField] private float time;

    public playerLife player;
    private void Start()
    {
        //player = FindObjectOfType<PlayerHealth>();
        trap = FindObjectOfType<Shooter>();

        // Verifica a escala do canh�o para determinar a dire��o da bola
        if (trap.transform.localScale.x < 0)  // Canh�o est� virado para a direita
        {
            // Acelera a bola para a direita
            rb.velocity = Vector2.right * speed;
        }
        else  // Canh�o est� virado para a esquerda
        {
            // Acelera a bola para a esquerda
            rb.velocity = Vector2.left * speed;
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
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject); // Destroi a bola ap�s o atraso especificado
    }
}