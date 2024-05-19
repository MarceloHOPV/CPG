using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
