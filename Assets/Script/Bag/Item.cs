using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BagMaterial",menuName = "BagMaterial/newItem")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public int itemCount;
    [TextArea] public string itemDescription;

}