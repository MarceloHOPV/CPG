using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dControl0 : MonoBehaviour
{

    [Header("Compnentes")]
    public GameObject dialogueObj;
    public Image profile;
    public Image profileJunin;
    public Text SpeechText;
    public Text actorNameText;
    public bool anda = false;
    public float moveSpeed;

    [Header("Setings")]
    public float TypingSpeed;
    private string[] sentences;
    public int index;

    private void Start()
    {
        SpeechText.text = "";
    }

    public void changeCharacter(Sprite p, string actorName)
    {
        profile.sprite = p;
        actorNameText.text = actorName;
    }

    public void speech(Sprite p, string[] txt, string actorName)
    {
        dialogueObj.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        actorNameText.text = actorName;
        StartCoroutine(typeSentence());
    }


    public void deactv()
    {
        SpeechText.text = "";
        dialogueObj.SetActive(false);
        index = 0;
    }


    IEnumerator typeSentence()
    {
        foreach (char letters in sentences[index].ToCharArray())
        {
            SpeechText.text += letters;
            yield return new WaitForSeconds(TypingSpeed);
        }
    }

    public void nexSentence()
    {
        if (SpeechText.text == sentences[index])
        {
            //Ainda a texto
            if (index < sentences.Length - 1)
            {
                index++;
                SpeechText.text = "";
                StartCoroutine(typeSentence());
            }
            //lido quando acaba o texto
            else
            {
                SpeechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                SceneManager.LoadScene(1);
            }
        }
    }

    IEnumerator WaitAndExecute(float delayInSeconds)
    {
        // Aguarda o tempo especificado em segundos
        yield return new WaitForSeconds(delayInSeconds);

        // Código para executar após a espera
        
    }

    public void preSentence()
    {
        Debug.Log("NextSentece");
        if (SpeechText.text == sentences[index])
        {
            //Ainda a texto
            Debug.Log("if");
            if (index < sentences.Length - 1)
            {
                if (index >= 1)
                    index--;
                SpeechText.text = "";
                StartCoroutine(typeSentence());
            }
            //lido quando acaba o texto
            else
            {
                Debug.Log("else");
                SpeechText.text = "";
                index = 0;
               

            }
        }
    }

}
