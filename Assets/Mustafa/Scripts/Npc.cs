using System.Collections;
using System.Collections.Generic;
using CubeEngine;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public NpcSC data;
    public AudioSource source;
    
    public void GetJoke(QuestionsReaction reaction)
    {
        switch (reaction)
        {
            case QuestionsReaction.Bad:
                Invoke(nameof(BreakTheTalk),data.reactionClips[0].length);
                source.clip = data.reactionClips[0];
                GameManager.Init.popularity--;
                source.Play();
                break;
            case QuestionsReaction.Normal:
                Invoke(nameof(BreakTheTalk),data.reactionClips[1].length);
                source.clip = data.reactionClips[1];
                GameManager.Init.popularity++;
                source.Play();
                break;
            case QuestionsReaction.Good:
                Invoke(nameof(BreakTheTalk),data.reactionClips[2].length);
                source.clip = data.reactionClips[2];
                GameManager.Init.popularity+=2;
                source.Play();
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
