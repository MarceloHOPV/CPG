using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // A posi��o de onde as bolas de canh�o ser�o lan�adas
    public Transform firepoint;

    // Prefab da bola de canh�o
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

        // Instancia uma nova bola de canh�o no firepoint (posi��o de lan�amento)
        Ball newBall = Instantiate(bullet, transform.position, transform.rotation);
        Debug.Log("Instanciou");

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
