using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TradeInf
{
    public int itemId;
    public int priceOffset;
    public int amount;

    public TradeInf(int _id, int _amount)
    {
        itemId = _id;
        amount = _amount;
    }
    public TradeInf(int _id, int _priceOffset, int _amount)
    {
        itemId = _id;
        priceOffset = _priceOffset;
        amount = _amount;
    }
}

public class ShopManager : MonoBehaviour
{
    public GridLayoutGroup itemGrid;
    public GameObject itemIconPrefab;
}
