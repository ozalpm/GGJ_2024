using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Init;
    public AudioSource source;
    public AudioSource musicSource;

    public float maxPopularity;
    private float m_popularity;
    public float popularity
    {
        set
        {
            m_popularity = Math.Clamp(value,0, maxPopularity);
            //UI_Manager.Init.PopularityChanged(m_popularity,maxPopularity); (Its remowing)
            
            Phone.Init.popularityText.text = $"%{(int)((m_popularity / maxPopularity)*100)}";
            Debug.Log(m_popularity / maxPopularity);
        }
        get
        {
            return (m_popularity / maxPopularity);
        }
    }

    private float m_followeCount;
    public float followerCount
    {
        set
        {
            m_followeCount = value;
            Phone.Init.followerCountText.text = ((int)m_followeCount).ToString();
        }
        get
        {
            return m_followeCount;
        }
    }
    
    public float m_bankBalance;
    public float bankBalance
    {
        set
        {
            m_bankBalance = value;
            Phone.Init.bankBalanceText.text = ((int)m_bankBalance).ToString();
            Phone.Init.shopBalanceText.text = ((int)m_bankBalance).ToString();
        }
        get
        {
            return m_bankBalance;
        }
    }
    
    private int m_postCount;
    public int postCount
    {
        set
        {
            m_postCount = value;
            Phone.Init.postCountText.text = ((int)m_postCount).ToString();
        }
        get
        {
            return m_postCount;
        }
    }

    public Transform homePos;
    public Transform streetPos;
    public bool isInHome;
    private void Awake()
    {
        Init = this;
    }

    private void Start()
    {
        StartCoroutine(nameof(GetFollower));
    }
    
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            popularity++;
        }
        
    }

    IEnumerator GetFollower()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            followerCount += (popularity);
            bankBalance += (followerCount / 10);
        }
    }

    public void TalkingMusicVolume(bool isTalikng)
    {
        if (isTalikng)
        {
            musicSource.volume = 0.5f;
        }
        else
        {
            musicSource.volume = 1;
        }
    }

    public void GoHome()
    {
        PlayerController.Init.transform.position = homePos.position;
        isInHome = true;
    }

    public void GoStreet()
    {
        PlayerController.Init.transform.position = streetPos.position;
        isInHome = false;
    }
}
