using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] public float move;
    [SerializeField] private float speed = 10;
    public Rigidbody2D rb;

    [SerializeField] public float Jump;
    [SerializeField] private float SpeedJump = 5;
    [SerializeField] private LayerMask groundLayer;
    public bool inGround;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        PlayerMovement();
        PlayerJump();
    }

    void PlayerMovement()
    {
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        if(move<0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,180,transform.eulerAngles.z);
        }
        else if(move>0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,0,transform.eulerAngles.z);
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
    }

    
}
