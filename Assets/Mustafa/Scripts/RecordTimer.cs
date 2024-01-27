using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecordTimer : MonoBehaviour
{
    public TMP_Text text;

    public int time;

    public void TimeReset()
    {
        time = 0;
    }

    public void TimeUp()
    {
        time++;
        string second = time%60<10? $"0{time%60}" : $"{time%60}";

        
        text.text = $"0{(int)(time/60)}:{second}";
    }
}
