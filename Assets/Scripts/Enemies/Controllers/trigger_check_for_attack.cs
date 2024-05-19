using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_check_for_attack : MonoBehaviour
{
    public EnemyController enemy;
    public float cooldown;
    public bool can_attack = true;

    private void Start()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("Player") && can_attack)
            {
                collision.GetComponent<playerLife>().takeDamage(2);
                enemy.attack();
                can_attack = false;
                Invoke("cooldown_passed", cooldown);
            }
            if(collision.CompareTag("tree") && can_attack)
            {
                collision.GetComponent<tree>().perderVida(2);
                enemy.attack();
                can_attack = false;
                Invoke("cooldown_passed", cooldown);
            }
        }
    }

    private void cooldown_passed()
    {
        can_attack = true;
    }

}