using System;
using System.Collections;
using System.Collections.Generic;
using CubeEngine;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public static Phone Init;
    
   

    public Animator phoneAnimator;

    public UnityEvent onStartLookPhone;
    public UnityEvent onFinishLookPhone;
    private bool onLooking;

    [Header("Bank")] 
    public TMP_Text bankBalanceText;

    [Header("Instagram")] 
    public TMP_Text followerCountText;
    public TMP_Text postCountText;
    public TMP_Text popularityText;


    [Header("Camera")]
    public GameObject redCircle;
    public RecordTimer recordTimer;
    public GameObject whiteCircle;
    public Animator reactionAnimator;
    
    
    private void Awake()
    {
        Init = this;
    }
    
    public void RecordStart()
    {
        redCircle.SetActive(true);
        whiteCircle.SetActive(false);
        recordTimer.text.gameObject.SetActive(true);
        recordTimer.TimeReset();
        recordTimer.TimeUp();
    }

    public void RecordEnd(QuestionsReaction reaction)
    {
        redCircle.SetActive(false);
        whiteCircle.SetActive(true);
        recordTimer.text.gameObject.SetActive(false);
        CallReactionAnimator(reaction);
    }

    public void CallReactionAnimator(QuestionsReaction reaction)
    {
        switch (reaction)
        {
            case QuestionsReaction.Bad:
                reactionAnimator.SetTrigger("Bad");
                break;
            case QuestionsReaction.Normal:
                reactionAnimator.SetTrigger("Normal");
                break;
            case QuestionsReaction.Good:
                reactionAnimator.SetTrigger("Good");
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (PlayerController.Init.isTalking) { return; }
            if (onLooking)
            {
                FinishLookPhone();
            }
            else
            {
                StartLookPhone();
            }
            
            Debug.Log("kapandı");
        }
    }

    public void StartLookPhone()
    {
        phoneAnimator.SetBool("Look",true);
        onStartLookPhone.Invoke();
        onLooking = true;
        PlayerController.Init.OpenPhone();
    }
    
    public void FinishLookPhone()
    {
        phoneAnimator.SetBool("Look",false);
        onFinishLookPhone.Invoke();
        onLooking = false;
        PlayerController.Init.ClosePhone();
    }

}
