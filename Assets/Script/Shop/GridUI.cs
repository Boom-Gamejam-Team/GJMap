using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(GridLayoutGroup))]
public class GridUI : MonoBehaviour
{
    public GameObject itemIconPrefab;
    public void AddNewItemIcon(Item item, int _id)
    {
        GameObject itemIcon = Instantiate(itemIconPrefab);
        itemIcon.transform.SetParent(transform);
        itemIcon.GetComponent<ItemTradeIcon>().SetIcon(item, _id);
    }
}
