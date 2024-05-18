using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Manager : MonoBehaviour
{

    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelSettings;

    

    public void openSetings()
    {
        painelMenuInicial.SetActive(false);
        painelSettings.SetActive(true);
    }
    public void closeSetings()
    {
        painelMenuInicial.SetActive(true);
        painelSettings.SetActive(false);
    }

    public void closeGame()
    {
        Debug.Log("O jogo fechou");
        Application.Quit();
    }

}
