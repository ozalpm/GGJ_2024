using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public static Phone Init;
    public GameObject redCircle;
    public RecordTimer recordTimer;
    public GameObject whiteCircle;
    
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

    public void RecordEnd()
    {
        redCircle.SetActive(false);
        whiteCircle.SetActive(true);
        recordTimer.text.gameObject.SetActive(false);
    }

}
