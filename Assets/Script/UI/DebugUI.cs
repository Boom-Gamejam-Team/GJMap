using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUI : MonoBehaviour
{
    public Item heal;
    public void ShowShop()
    {
        List<TradeInf> tradeInfs = new()
        {
            new TradeInf(heal, 2, 1),
            new TradeInf(heal, 3, 1)
        };
        ShopManager.Instance.ShowShop(tradeInfs);
    }
}
