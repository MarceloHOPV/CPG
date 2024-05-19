using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tree : MonoBehaviour
{
    public int vida;
    public int vidaMax;
    public GameObject barra;
    public float porcentagem;
    public float tamanho;

    void Start()
    {
        barra = GameObject.FindWithTag("vida");
        vida = vidaMax;
        tamanho = barra.GetComponent<Transform>().localScale.x;
        Debug.Log(tamanho);
    }
    public void perderVida(int dano)
    {
        vida -= dano;
        porcentagem = vida*100/vidaMax;
        Debug.Log(porcentagem);
        Debug.Log(tamanho);
        barra.GetComponent<Transform>().localScale = new Vector3(tamanho*(porcentagem/100), barra.GetComponent<Transform>().localScale.y, barra.GetComponent<Transform>().localScale.z);
        if(vida <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
