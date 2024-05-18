using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // A posição de onde as bolas de canhão serão lançadas
    public Transform firepoint;

    // Prefab da bola de canhão
    public Ball bullet;

    // Tempo entre cada disparo
    public float timeBetween;

    // Tempo inicial entre disparos
    public float StartTimeBetween;

    public ShooterAnimation anim;

    //Vida
    public int vida;

    // sinaliza que esta sendo atacado
    public bool beingAttacked = false;

    //sinaliza que esta destruido
    private bool destroyed = false;

    void Start()
    {
        // Inicializa o tempo entre disparos com o valor definido no Inspector
        timeBetween = StartTimeBetween;
    }

    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        // Verifica se o tempo entre disparos chegou a zero
        if (timeBetween <= 0 && !destroyed)
        {
            //anim.PlayAnimation("ShooterAttack");
            // Reinicia o tempo entre disparos
            NewBall();
            timeBetween = StartTimeBetween;
            Debug.Log("Atirou");
        }
        else
        {
            // Reduz o tempo entre disparos com base no tempo decorrido
            timeBetween -= Time.deltaTime;
            Debug.Log("Aguardando");
        }
    }

    public void StopAttacking()
    {
        //anim.PlayAnimation("ShooterIdle");
    }

    public void StopbeingAttacked()
    {
        beingAttacked = false;
    }

    public void NewBall()
    {

        // Instancia uma nova bola de canhão no firepoint (posição de lançamento)
        Ball newBall = Instantiate(bullet, firepoint.position, firepoint.rotation);
        Debug.Log("Instanciou");

        // Verifica a escala do canhão para determinar a direção da bola
        if (transform.localScale.x < 0)
        {
            // Se o canhão estiver virado para a esquerda, inverte a escala da bola
            newBall.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void PerdeVida(int dano)
    {
        beingAttacked = true;
        vida -= dano;
        StopAttacking();
        if (vida <= 0)
        {
            destroyed = true;
            Destroy();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject, 0.1f);
    }
}
