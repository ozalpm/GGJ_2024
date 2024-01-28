using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopElement", menuName = "ScriptableObjects/ShopElement")]

public class ShopElementSC : ScriptableObject
{
    public int price;
    public Sprite shopImage;
    public GameObject shoppedObject;
    public string objectName;
}
