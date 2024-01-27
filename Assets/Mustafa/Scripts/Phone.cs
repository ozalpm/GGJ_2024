using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public static Phone Init;
    public GameObject recordingAnimObject;
    public RecordTimer recordTimer;
    public GameObject whitePoint;
    
    private void Awake()
    {
        Init = this;
    }
    
    public void RecordStart()
    {
        recordingAnimObject.SetActive(true);
        whitePoint.SetActive(false);
        recordTimer.TimeReset();
        recordTimer.TimeUp();
    }

    public void RecordEnd()
    {
        recordingAnimObject.SetActive(false);
        whitePoint.SetActive(true);
    }

}
