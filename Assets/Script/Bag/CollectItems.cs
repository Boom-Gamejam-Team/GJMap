using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public Item thisItem;
    public Inventory thisInventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            AddNewItem(thisItem,thisInventory);
            Destroy(gameObject);
        }

    }
    //收集物品进包
    public void AddNewItem(Item item, Inventory inventory)
    {
        if (!inventory.bagList.Contains(item))
        {
            inventory.bagList.Add(item);
        }
        else
        {
            item.itemCount += 1;
        }
    }
}
