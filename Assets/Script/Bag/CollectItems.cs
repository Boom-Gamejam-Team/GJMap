using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public Item thisItem;
    public Inventory thisInventory;
    public int itemMaxCount = 18;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            AddNewItem(thisItem,thisInventory);
            Destroy(gameObject);
        }

    }
    //�ռ���Ʒ����
    public void AddNewItem(Item item, Inventory inventory)
    {
        if (inventory.bagList.Count <= itemMaxCount)
        {
            if (!inventory.bagList.Contains(item))
            {
                inventory.bagList.Add(item);
            }
            else
            {
                item.itemCount += 1;
            }
            BagManager.Refresh();
        }
    }
}
