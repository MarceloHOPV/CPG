using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    public void closeGame()
    {
        Debug.Log("O jogo fechou");
        Application.Quit();
    }
}
