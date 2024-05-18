using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLife : MonoBehaviour
{
    public int maxLife;
    public int currentLife;


    void Start()
    {
        currentLife = maxLife;
    }
    public void takeDamage(int dano)
    {
        currentLife -= dano;
        if(currentLife<=0)
        {
            Destroy(gameObject);
        }
    }

}
