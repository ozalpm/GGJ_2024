using System;
using System.Collections;
using System.Collections.Generic;
using CubeEngine;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public NpcSC data;
    public AudioSource source;
    public Animator animator;

    public QuestionsReaction reactedReaction;

    public void StartTheTalk()
    {
        animator.SetTrigger("Start Talk");
        Vector3 playerPos = PlayerController.Init.transform.position;
        transform.LookAt(new Vector3(playerPos.x,transform.position.y,playerPos.z));
    }

    public void GetJoke(QuestionsReaction reaction)
    {
        reactedReaction = reaction;
        switch (reaction)
        {
            case QuestionsReaction.Bad:
                Invoke(nameof(BreakTheTalk),3);
                source.clip = data.reactionClips[0];
                GameManager.Init.popularity-=2;
                animator.SetTrigger("Bad");
                source.Play();
                break;
            case QuestionsReaction.Normal:
                Invoke(nameof(BreakTheTalk),3);
                source.clip = data.reactionClips[1];
                GameManager.Init.popularity++;
                animator.SetTrigger("Normal");
                source.Play();
                break;
            case QuestionsReaction.Good:
                Invoke(nameof(BreakTheTalk),3);
                source.clip = data.reactionClips[2];
                GameManager.Init.popularity+=2;
                animator.SetTrigger("Good");
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
        Phone.Init.RecordEnd(reactedReaction);
        animator.SetTrigger("End Talk");
        GameManager.Init.postCount++;
    }

    public float GetAnimTime(String animName)
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach(AnimationClip clip in clips)
        {
            switch(animName)
            {
                case "Bad":
                    return clip.length;
                    break;
                case "Normal":
                    return clip.length;
                    break;
                case "Good":
                    return clip.length;
                    break;
            }
        }

        return 0;
    }
}
