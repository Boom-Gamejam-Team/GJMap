using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public Item thisItem;
    public CardItem cardItem;
    public Inventory thisInventory;
    public int itemMaxCount = 18;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            AddNewItem(thisItem,cardItem,thisInventory);
            Destroy(gameObject);
        }

    }
    //收集物品进包
    public void AddNewItem(Item item, CardItem cardItem,Inventory inventory)
    {
        if (inventory.bagList.Count <= itemMaxCount)
        {
            if (!inventory.bagList.Contains(item)&&!inventory.cardList.Contains(cardItem))
            {
                inventory.bagList.Add(item);
                inventory.cardList.Add(cardItem);
            }
            else
            {
                item.itemCount += 1;
            }
            BagManager.Refresh();
        }
    }
}
