using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopGrid : Grid
{
    public List<TradeInf> tradeList = new List<TradeInf>();

    public ShopGrid(GridType _type, Vector2 _hexPos, int _id) : base(_type, _hexPos, _id)
    {

    }
    public override void OnEnter()
    {

    }
    private void ShowShopUI()
    {

    }
}
