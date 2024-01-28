using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public GameObject[] objects;
    public Renderer[] wallRenderer;
    public Renderer planeRenderer;

    public static Home Init;
    private void Awake()
    {
        Init = this;
    }

    public void OpenObject(int id)
    {
        objects[id].SetActive(true);
    }
    
    public void ChangePlaneMaterial(Material material)
    {
        
        planeRenderer.material = material;
    }
    
    public void ChangeWallMaterial(Material material)
    {
        for (int i = 0; i < wallRenderer.Length; i++)
        {
            wallRenderer[i].material = material;
        }
        
    }
}
