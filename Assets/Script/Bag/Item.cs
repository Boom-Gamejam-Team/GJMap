using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BagMaterial", menuName = "BagMaterial/newItem")]
public class Item : ScriptableObject
{
    public string itemName;
    public int itemCount;
    public Sprite itemImage;
    
    public int itemBaseValue;
    [TextArea] public string itemDescription;
    public GameObject itemContainer;

}
