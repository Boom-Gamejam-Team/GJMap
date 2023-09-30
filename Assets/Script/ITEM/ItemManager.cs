using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public List<Item> itemList = new List<Item>();
    public Item FindItemByName(string name)
    {
        foreach (var item in itemList)
        {
            if (item.itemName == name)
            {
                return item;
            }
        }
        return null;
    }
}
