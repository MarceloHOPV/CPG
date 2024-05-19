using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu_Manager : MonoBehaviour
{

    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelSettings; 
    public AudioSource audioSource;

    public Slider volumeSlider;
    float sliderValue = 0f;

    void Start()
    {
        // Inicializa o slider na posi��o de 50% (0.5) que � a metade do volume m�ximo
        volumeSlider.value = 0.5f;
        // Adiciona um ouvinte para o evento de mudan�a de valor do slider
        audioSource.Play();
    }

    private void Update()
    {
        sliderValue = volumeSlider.value;
        audioSource.volume = sliderValue;
    }
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
