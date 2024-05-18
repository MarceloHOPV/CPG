using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_check_for_attack : MonoBehaviour
{
    public EnemyController enemy;
    public float cooldown;
    public bool can_attack = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("Player") && can_attack)
            {
                enemy.attack(collision.GetComponent<playerLife>());
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