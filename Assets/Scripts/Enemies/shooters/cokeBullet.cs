using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class cokeBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private Shooter shooter;
    [SerializeField] private float time;
    //public PlayerHealth player;

    private void Start()
    {
        //player = FindObjectOfType<PlayerHealth>();
        shooter = FindObjectOfType<Shooter>();

        // Verifica a escala do canhão para determinar a direção da bola
        if (shooter.transform.localScale.x < 0)  // Canhão está virado para a direita
        {
            // Acelera a bola para a direita
            rb.velocity = Vector2.right * speed;
        }
        else  // Canhão está virado para a esquerda
        {
            // Acelera a bola para a esquerda
            rb.velocity = Vector2.left * speed;
        }

        // Inicia a contagem regressiva para destruir a bola após 2 segundos
        StartCoroutine(DestroyAfterDelay(time));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //player.TakeDamage(damage);
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
        Destroy(gameObject); // Destroi a bola após o atraso especificado
    }
}
