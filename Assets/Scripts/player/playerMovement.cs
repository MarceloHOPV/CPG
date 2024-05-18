using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
<<<<<<< HEAD
=======
    public bool atacando;

>>>>>>> 82ee1ddba0142d1a14e5b76db323d3651061765e
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
<<<<<<< HEAD
        if (isMoving)
=======
        if (isMoving && !atacando)
>>>>>>> 82ee1ddba0142d1a14e5b76db323d3651061765e
        {
            SpriteFlip(move);
            rb.velocity = new Vector2(move * speed, rb.velocity.y);

            if (inGround)
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
<<<<<<< HEAD
            // Se está atacando, define a velocidade do jogador como zero
=======
            // Se estï¿½ atacando, define a velocidade do jogador como zero
>>>>>>> 82ee1ddba0142d1a14e5b76db323d3651061765e
            rb.velocity = new Vector2(0, rb.velocity.y);
            isMoving = false;
        }
    }

<<<<<<< HEAD
    void SpriteFlip(float horizontal)
    {
        // Obtém a escala atual do jogador
=======
    public void playerAtack()
    {
        if(!atacando)
            atacando = true;
        else
            atacando = false;
    }
    
    void SpriteFlip(float horizontal)
    {
        // Obtï¿½m a escala atual do jogador
>>>>>>> 82ee1ddba0142d1a14e5b76db323d3651061765e
        Vector3 playerScale = transform.localScale;

        if (horizontal > 0)
        {
            // Define a escala do jogador diretamente
<<<<<<< HEAD
            transform.localScale = new Vector3(Mathf.Abs(playerScale.x), playerScale.y, playerScale.z);
        }
        else if (horizontal < 0)
        {
            // Inverte a escala do jogador na direção horizontal
            transform.localScale = new Vector3(-Mathf.Abs(playerScale.x), playerScale.y, playerScale.z);
=======
            transform.eulerAngles = new Vector3(playerScale.x, 0, playerScale.z);
        }
        else if (horizontal < 0)
        {
            // Inverte a escala do jogador na direï¿½ï¿½o horizontal
            transform.eulerAngles = new Vector3(playerScale.x, 180, playerScale.z);
>>>>>>> 82ee1ddba0142d1a14e5b76db323d3651061765e
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

<<<<<<< HEAD
        if (rb.velocity.y > 0 && !inGround)
=======
        if (rb.velocity.y > 0 && !inGround && !atacando)
>>>>>>> 82ee1ddba0142d1a14e5b76db323d3651061765e
        {
            pa.PlayAnimation("PlayerJump");
        }
    }



}
