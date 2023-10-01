using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class ItemTradeIcon : MonoBehaviour
{
    public int id;
    public Item item;
    public void SetIcon(Item _item, int _id)
    {
        id = _id;
        item = _item;
        GetComponent<Image>().sprite = item.itemImage;
        GetComponent<Button>().onClick.AddListener(delegate () { ShopManager.Instance.ChooseTrade(this); });
    }
}
