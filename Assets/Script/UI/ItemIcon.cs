using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class ItemIcon : MonoBehaviour
{
    public void SetIcon(Item item)
    {
        GetComponent<Image>().sprite = item.itemImage;
        GetComponent<Button>().onClick.AddListener(delegate () { ShopManager.Instance.ChooseItem(item); });
    }
}
