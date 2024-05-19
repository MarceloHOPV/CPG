using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    public int vida;
    public int vidaMax;

    void Start()
    {
        vida = vidaMax;
    }
    public void perderVida(int dano)
    {
        vida -= dano;
        if(vida <= 0)
        {
            Debug.Log("Perdeu");
        }
    }

}
