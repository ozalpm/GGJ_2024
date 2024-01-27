using System.Collections;
using System.Collections.Generic;
using CubeEngine;
using UnityEngine;
using UnityEngine.UI;

public class Question_UI_Element : MonoBehaviour
{
    public string questionString;
    public Text questionText;
    public QuestionsReaction reaction;

    public AudioClip clip;

    public void Setup()
    {
        questionText.text = questionString;
    }
    
    public void StartQuestion()
    {
        UI_Manager.Init.CloseQuestionsPanel();
        GameManager.Init.source.clip = clip;
        GameManager.Init.source.Play();
        Invoke(nameof(QuestionEnd),clip.length);
    }

    private void QuestionEnd()
    {
        UI_Manager.Init.MakeAJoke(reaction);
    }
}
