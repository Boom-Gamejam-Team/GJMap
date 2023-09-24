using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Apple : Card
{
    
    // Start is called before the first frame update
    void Start()
    {
        CardName = "Apple";
        CardTitle = "Apple";
        IsUsed = false;
    }

    // Update is called once per frame
    public override void UseThis()
    {
        Debug.Log("³ÔÆ»¹û");
        Turn.This_Turn.ThisTurn.ACTIONOVER();
        Turn.This_Turn.ThisTurn.Attribute.currentSpeed += (int)5.0f;
        Gamemanager.CardBag.Remove(this.gameObject);
        FightCardManager.instance.Cards.Remove(this.gameObject.GetComponent<Card>());
        FightCardManager.instance.usedCards.Add(this.gameObject.GetComponent<Card>());//·ÅÈëÆúÅÆ¶Ñ
    }
    public override void SetMark(bool mark)
    {
        IsInitialed = mark;
    }
}
