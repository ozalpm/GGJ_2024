using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Init;

    private float m_popularity;
    public AudioSource source;
    public float popularity
    {
        set
        {
            m_popularity = Math.Clamp(value,0, maxPopularity);
            UI_Manager.Init.PopularityChanged(m_popularity,maxPopularity);
        }
        get
        {
            return m_popularity;
        }
    }
    
    public float maxPopularity;
    private void Awake()
    {
        Init = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            popularity++;
        }
        
    }
}
