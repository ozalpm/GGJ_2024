using System;
using System.Collections;
using System.Collections.Generic;
using CubeEngine;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public static Phone Init;
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

}
