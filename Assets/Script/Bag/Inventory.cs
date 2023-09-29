using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BagMaterial", menuName = "BagMaterial/newBag")]
public class Inventory : ScriptableObject
{
    public List<Item> bagList= new List<Item>();

    
}
