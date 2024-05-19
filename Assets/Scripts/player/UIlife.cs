using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIlife : MonoBehaviour
{
    public int vida;
    public int vida_maxima = 5;
    private playerLife pl;

    [SerializeField] public GameObject[] folhas;
    // Start is called before the first frame update
    void Start()
    {
        pl = FindAnyObjectByType<playerLife>();
    }

    // Update is called once per frame
    void Update()
    {
        vida = pl.currentLife;
        for (int i = 0; i < folhas.Length; i++)
        {
            if(i < vida)
            {
                folhas[i].gameObject.SetActive(true);
            }
            else
            {
                folhas[i].gameObject.SetActive(false);
            }
        }
    }
}
