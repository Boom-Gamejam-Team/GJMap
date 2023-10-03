using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ShopGrid : Grid
{
    public List<TradeInf> tradeList = new List<TradeInf>();

    public ShopGrid(GridType _type, Vector2 _hexPos, int _id) : base(_type, _hexPos, _id)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();
        if (tradeList.Count > 0)
            ShopManager.Instance.ShowShop(tradeList);
    }

}
