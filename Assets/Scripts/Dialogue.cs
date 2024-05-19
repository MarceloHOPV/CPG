using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Profiling;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public Sprite profileVo;
    public Sprite profileJunin;
    public string[] speechTxt;
    public string actorName;
    public string vovoName;
    public string junimName;
    public AudioSource[] music;

    public LayerMask playerLayer;
    public float radious;

    private Dialogue_Control dc;
    bool onRadious = false;
    bool alreadSpeaking;
    public bool f0 = false, f1 = false, f2 = false, f3 = false;

    public GameObject Evento;

    private void Start()
    {
        dc = FindAnyObjectByType<Dialogue_Control>();
    }

    private void Update()
    {
        if (onRadious)
        {
            dc.speech(profile, speechTxt, actorName);
            onRadious = false;
        }

        switch (dc.index)
        {
            case 0:
                profile = profileJunin;
                actorName = junimName;
                if (!f0)
                {
                    dc.changeCharacter(profile, actorName);
                    f0 = true;
                }
                break;
            case 1:
                Debug.Log("1");
                profile = profileVo;
                actorName = vovoName;
                if (!f1)
                {
                    dc.changeCharacter(profile, actorName);
                    f1 = true;
                    music[0].Stop();
                    music[1].Play();
                    
                }
                break;
            case 2:
                Debug.Log("2");
                profile = profileJunin;
                actorName = junimName;
                if (!f2)
                {
                    dc.changeCharacter(profile, actorName);
                    f2 = true;
                    music[1].Stop();
                    music[2].Play();
                }
                break;
            case 3:
                Debug.Log("3");
                profile = profileVo;
                actorName = vovoName;
                if (!f3)
                {
                    dc.changeCharacter(profile, actorName);
                    f3 = true;
                    music[2].Stop();
                    music[3].Play();
                }
                break;
                Debug.Log(dc.index);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onRadious = true;
            music[0].Play();
            // Adicione qualquer outro código que deva ser executado quando o jogador entrar no trigger
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Verifica se o objeto que colidiu tem a tag "Player"
        if (collision.CompareTag("Player"))
        {
            alreadSpeaking = false;
            onRadious = false;
            dc.deactv();
            Evento.SetActive(false);
            // Adicione qualquer outro código que deva ser executado quando o jogador sair do trigger
        }
    }
}
