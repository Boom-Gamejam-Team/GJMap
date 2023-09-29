using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeInf
{
    public int itemId;
    public int price;
    public int amount;
    public TradeInf(int _id, int _price, int _amount)
    {
        itemId = _id;
        price = _price;
        amount = _amount;
    }
}

public class ShopGrid : Grid
{
    public List<TradeInf> tradeList = new List<TradeInf>();

    public ShopGrid(GridType _type, Vector2 _hexPos, int _id) : base(_type, _hexPos, _id)
    {

    }
}
