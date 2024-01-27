using System;
using System.Collections;
using System.Collections.Generic;
using CubeEngine;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Init;
    [Header("npc info panel")] public GameObject infoPanel;
    public Text npcNameText;

    [Header("Questions Panel")] public GameObject questionsPanel;
    public Transform questionContent;
    public Question_UI_Element questionUIElement;

    [Header("General")]
    public Image popularityImage;
    

    private void Awake()
    {
        Init = this;
    }
    
    public void PopularityChanged(float val, float max)
    {
        popularityImage.fillAmount = val / max;
    }

    public void OpenInfoPanel(Npc npc)
    {
        infoPanel.SetActive(true);
        questionsPanel.SetActive(false);
        npcNameText.text = npc.data.npcName;
    }
    
    public void CloseInfoPanel()
    {
        infoPanel.SetActive(false);
        questionsPanel.SetActive(false);
    }
    
    public void OpenQuestionsPanel(Npc npc)
    {
        infoPanel.SetActive(false);
        questionsPanel.SetActive(true);
        List<GameObject> questionContentGameObjects=new List<GameObject>();

        for (int i = 0; i < questionContent.childCount; i++)
        {
            questionContentGameObjects.Add(questionContent.GetChild(i).gameObject);
        }
        if (questionContentGameObjects.Count>0)
        {
            foreach (var var in questionContentGameObjects)
            {
                Destroy(var);
            }
        }
        

        foreach (var var in npc.data.questionsGroups[Random.Range(0,npc.data.questionsGroups.Length)].questions)
        {
            Question_UI_Element element = Instantiate(questionUIElement, questionContent);
            element.reaction = var.questionsReaction;
            element.questionString = var.questionString;
            element.clip = var.clip;
            
            element.Setup();
        }
    }
    
    public void CloseQuestionsPanel()
    {
        infoPanel.SetActive(false);
        questionsPanel.SetActive(false);
        
    }

    public void MakeAJoke(QuestionsReaction reaction)
    {
        CloseQuestionsPanel();
        PlayerController.Init.MakeTheJoke(reaction);
    }
}
