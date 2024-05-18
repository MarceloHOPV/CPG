using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisor_chao_inimigo : MonoBehaviour
{
    public EnemyController inimigo;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("chao"))
            {
                inimigo.Flip();
            }

        }
    }
}