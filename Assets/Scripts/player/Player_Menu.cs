using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Menu : MonoBehaviour
{

    //unity instances
    private Sprite profile;
    public Sprite profileJunin;
    public Sprite profileVo;
    public string[] speechTxt;
    public string juninName;
    public string vovoName;
    private string actorName;
    [SerializeField] private GameObject painelMenuInicial;
    public SpriteRenderer sprite;
    public Animator _animator;
    public string _currentState;
    public AudioSource[] music;
    //music.Play();

    //C#
    private dControl0 dc;
    bool onRadious = false;
    bool alreadSpeaking = false;
    bool f0 = false, f1 = false, f2 = false, f3 = false, f4 = false, f5 = false, f6 = false,f7 = false;

    //Const animation
    const string PLAYER_IDLE = "IDLE";
    const string PLAYER_WAKING = "WakeUp";


    private void Start()
    {
        dc = FindAnyObjectByType<dControl0>();
        sprite = GetComponent<SpriteRenderer>();
        _animator = gameObject.GetComponent<Animator>();
    }

    IEnumerator DelayCoroutine()
    {
        // Aguarda 45 segundos
        yield return new WaitForSeconds(70);

        // O código abaixo será executado após o delay de 45 segundos
        // Adicione aqui o código que você quer executar após o delay
    }
    protected bool isAnimationPlaying(Animator animator, string stateName)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(stateName) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    private void Update()
    {
        if (onRadious == true)
        {
            if (!isAnimationPlaying(_animator, PLAYER_WAKING))
            {
                ChangeAnimationState(PLAYER_IDLE);
                StartCoroutine(DelayCoroutine());
            }
        }
        Debug.Log(dc.index);
            switch (dc.index)
            {
                case 0:
                    profile = profileVo;
                    actorName = vovoName;
                    if (!f0)
                    {
                        dc.changeCharacter(profile, actorName);
                        f0 = true;
                    }
                break;
                case 1:
                    
                    if (!f1)
                    {
                        dc.changeCharacter(profile, actorName);
                        f1 = true;
                        music[1].Play();
                    }
                break;
                case 2:
                    
                    profile = profileJunin;
                    actorName = juninName;
                if (!f2)
                {
                    dc.changeCharacter(profile, actorName);
                    f2 = true;
                    music[2].Play();    
                }
                break;
                case 3:
                    
                    profile = profileVo;
                    actorName = vovoName;
                if (!f3)
                {
                    dc.changeCharacter(profile, actorName);
                    f3 = true;
                    music[3].Play();
                }
                break;case 4:
                    
                    profile = profileJunin;
                    actorName = juninName;
                if (!f4)
                {
                    dc.changeCharacter(profile, actorName);
                    f4 = true;
                    music[4].Play();
                }
                break;
                case 5:
                    
                    profile = profileVo;
                    actorName = vovoName;
                if (!f5)
                {
                    dc.changeCharacter(profile, actorName);
                    f5 = true;
                    music[5].Play();
                }
                break;
                case 6:
                    
                    profile = profileVo;
                    actorName = vovoName;
                if (!f6)
                {
                    dc.changeCharacter(profile, actorName);
                    f6 = true;
                    music[6].Play();
                }
                break;

        }
    }

    protected void ChangeAnimationState(string newState)
    {
        if (newState == _currentState)
        {
            return;
        }

        _animator.Play(newState);
        _currentState = newState;
    }


    public void newGame()
    {
        onRadious = true;
        if (onRadious && !alreadSpeaking)
        {
            ChangeAnimationState(PLAYER_WAKING);
            dc.deactv();
            dc.speech(profile, speechTxt, actorName);
            alreadSpeaking = true;
            music[0].Play();

        }
        alreadSpeaking = true;
    }
}
