using System.Collections;
using System.Collections.Generic;
using CubeEngine;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public NpcSC data;

    
    public void GetJoke(QuestionsReaction reaction)
    {
        switch (reaction)
        {
            case QuestionsReaction.Bad:
                BreakTheTalk();
                break;
            case QuestionsReaction.Normal:
                BreakTheTalk();
                break;
            case QuestionsReaction.Good:
                BreakTheTalk();
                break;
            default:
                break;
        }
    }

    public void BreakTheTalk()
    {
        gameObject.layer = 0;
        PlayerController.Init.TalkingIsEnd();
    }
}
