using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialogue_Control : MonoBehaviour
{

    [Header("Compnentes")]
    public GameObject dialogueObj;
    public Image profile;
    public Image profileJunin;
    public Text SpeechText;
    public Text actorNameText;
    public Rigidbody2D rboss;
    public SpriteRenderer sp;
    public bool anda = false;
    public float moveSpeed;

    [Header("Setings")]
    public float TypingSpeed;
    private string[] sentences;
    public int index;
    public float horizontal = 0f;

    private void Start()
    {
        SpeechText.text = "";
    }

    public void changeCharacter(Sprite p,string actorName)
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

    private void FixedUpdate()
    {
        if(anda)
        {
            if(horizontal < 1.0f)
            {
                horizontal += 0.1f;
            }
            Vector2 position = rboss.transform.position;
            position.x += moveSpeed * horizontal * Time.deltaTime;
            rboss.transform.position = position;
        }
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
                //dialogueObj.SetActive(false);
                sp.flipX = true;
                StartCoroutine(WaitAndExecute(15));
                anda = true;
            }
        }
    }

    IEnumerator WaitAndExecute(float delayInSeconds)
    {
        // Aguarda o tempo especificado em segundos
        yield return new WaitForSeconds(delayInSeconds);

        // Código para executar após a espera
        Debug.Log("Executado após " + delayInSeconds + " segundos.");
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
                if(index >=1)
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
                dialogueObj.SetActive(false);

            }
        }
    }

}
