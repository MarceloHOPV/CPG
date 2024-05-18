using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public bool atacando;

    [SerializeField] public float move;
    [SerializeField] private float speed = 10;
    public Rigidbody2D rb;
    public bool isMoving;

    [SerializeField] public float Jump;
    [SerializeField] private float SpeedJump = 5;
    [SerializeField] private LayerMask groundLayer;
    public bool inGround;

    [SerializeField] private PlayerAnimation pa;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        pa = GetComponent<PlayerAnimation>();
    }
    void FixedUpdate()
    {
        PlayerMovement();
        PlayerJump();
    }

    void PlayerMovement()
    {

        move = Input.GetAxis("Horizontal");
        isMoving = true;

        // Verifica se o jogador pode se mover
        if (isMoving)
        {
            SpriteFlip(move);
            rb.velocity = new Vector2(move * speed, rb.velocity.y);

            if (inGround && !atacando)
            {
                if (move == 0)
                {
                    pa.PlayAnimation("PlayerIdle");
                }
                else
                {
                    pa.PlayAnimation("PlayerWalk");
                }
            }
        }
        else
        {
            // Se est� atacando, define a velocidade do jogador como zero
            rb.velocity = new Vector2(0, rb.velocity.y);
            isMoving = false;
        }
    }

    public void playerAtack()
    {
        if(!atacando)
            atacando = true;
        else
            atacando = false;
    }
    
    void SpriteFlip(float horizontal)
    {
        // Obt�m a escala atual do jogador
        Vector3 playerScale = transform.localScale;

        if (horizontal > 0)
        {
            // Define a escala do jogador diretamente
            transform.eulerAngles = new Vector3(playerScale.x, 0, playerScale.z);
        }
        else if (horizontal < 0)
        {
            // Inverte a escala do jogador na dire��o horizontal
            transform.eulerAngles = new Vector3(playerScale.x, 180, playerScale.z);
        }
    }

    void PlayerJump()
    {
        /*valor teste, trocar por um valor adaptavel*/
        inGround = Physics2D.OverlapCircle(new Vector2(transform.position.x,transform.position.y-0.5f), 0.5f, groundLayer);
        Jump = Input.GetAxis("Jump");
        if(inGround)
        {
            rb.AddForce(new Vector2(0f, Jump*SpeedJump), ForceMode2D.Impulse);
        }

        if (rb.velocity.y > 0 && !inGround && !atacando)
        {
            pa.PlayAnimation("PlayerJump");
        }
    }



}
