using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBag : MonoBehaviour
{
    public Item item;
    public Image image;
    public Text itemNum;

    public void ItemInfo()
    {
        BagManager.UpdateInfo(item.itemDescription);
    }
}
