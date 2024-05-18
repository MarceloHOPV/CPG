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

    //C#
    private Dialogue_Control dc;
    bool onRadious = false;
    bool alreadSpeaking = false;
    bool f1 = false, f2 = false, f3 = false, f4 = false, f5 = false, f6 = false;

    //Const animation
    const string PLAYER_IDLE = "IDLE";
    const string PLAYER_WAKING = "WakeUp";


    private void Start()
    {
        dc = FindAnyObjectByType<Dialogue_Control>();
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
                break;
                case 1:
                    Debug.Log("1");
                    break;
                case 2:
                    Debug.Log("2");
                    profile = profileJunin;
                    actorName = juninName;
                if (!f2)
                {
                    dc.changeCharacter(profile, actorName);
                    f2 = true;
                    Debug.Log("lmao");
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
                }
                break;
                case 4:
                    Debug.Log("4");
                    profile = profileJunin;
                    actorName = juninName;
                    dc.changeCharacter(profile, actorName);
                if (!f4)
                {
                    dc.changeCharacter(profile, actorName);
                    f4 = true;
                }
                break;
                case 5:
                    Debug.Log("4");
                    profile = profileVo;
                    actorName = vovoName;
                if (!f5)
                {
                    dc.changeCharacter(profile, actorName);
                    f5 = true;
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

        }
        alreadSpeaking = true;
    }
}
