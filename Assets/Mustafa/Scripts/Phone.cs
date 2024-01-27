using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public static Phone Init;
    public GameObject recordingAnimObject;
    
    private void Awake()
    {
        Init = this;
    }
    
    public void RecordStart()
    {
        recordingAnimObject.SetActive(true);
    }

    public void RecordEnd()
    {
        recordingAnimObject.SetActive(false);
    }

}
