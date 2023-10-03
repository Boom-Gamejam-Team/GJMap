using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoneyGrid : Grid
{
    public enum BonusType
    {
        Money, Card, Item
    }
    public BonusType bounsType;

    public int moneyNum;
    public List<Card> cardList = new List<Card>();
    public List<Item> itemList = new List<Item>();

    public List<TradeInf> tradeList = new List<TradeInf>();

    private bool isVisited = false;
    public MoneyGrid(GridType _type, Vector2 _hexPos, int _id) : base(_type, _hexPos, _id)
    {

    }
    public override void OnEnter()
    {
        base.OnEnter();
        GiveBonus();
    }
    void GiveBonus()
    {
        if (isVisited) return;
        switch (bounsType)
        {
            case BonusType.Money:
                GeneralData.instance.generalData.playerMoney += moneyNum;
                Debug.Log("Money added");
                break;
            case BonusType.Card:
                GeneralData.instance.generalData.cards.AddRange(cardList);
                Debug.Log("card added");
                break;
            case BonusType.Item:
                Debug.Log("item added");
                break;
            default:
                break;
        }
        isVisited = true;
    }
}