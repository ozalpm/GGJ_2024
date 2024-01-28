using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopElement : MonoBehaviour
{
    public ShopElementSC data;
    public float price;

    public Material material;
    public void BuyObject(int id)
    {
        if (GameManager.Init.bankBalance>=price)
        {
            GameManager.Init.bankBalance -= price;
            Home.Init.OpenObject(id);
            Destroy(gameObject);
        }
    }

    public void BuyWallMaterial()
    {
        if (GameManager.Init.bankBalance>=price)
        {
            GameManager.Init.bankBalance -= price;
            
            Home.Init.ChangeWallMaterial(material);
            Destroy(gameObject);
        }
    }
    
    public void BuyPlaneMaterial()
    {
        if (GameManager.Init.bankBalance>=price)
        {
            GameManager.Init.bankBalance -= price;
            Home.Init.ChangePlaneMaterial(material);
            Destroy(gameObject);
        }
    }
}
