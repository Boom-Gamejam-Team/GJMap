using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCardManager:MonoBehaviour
{
    public static FightCardManager instance=new FightCardManager();//单例
    public List<GameObject> AllCards = new List<GameObject>();
    public List<Card> Cards = new List<Card>();//抽牌堆
    public List<Card> usedCards = new List<Card>();//弃牌堆
    // Start is called before the first frame update
    public void FightInit()//进入战斗时
    {
        AllCards.AddRange(Gamemanager.CardBag);
        TurnInit();
        //方便生成实例时记录卡牌（因为生成的卡牌物体不是背包中的卡牌）
    }
    public void TurnInit()//回合开始时洗牌
    {
        List<Card> Temp = new List<Card>(); 

        foreach (var card in AllCards)
            Temp.Add(card.GetComponent<Card>());

        while(Temp.Count > 0)
        {
            int Rad=Random.Range(0,Temp.Count);

            Cards.Add(Temp[Rad]);

            Temp.RemoveAt(Rad);
        }
    }
    
    public void CardWash(int Count)//从后往前加入牌
    {
        if (Count > usedCards.Count)
            Count = usedCards.Count;
        for(int i=0;i<Count;i++)
        {
            Cards.Add(usedCards[i]);
        }
    }
    //抽牌
    public void CardCreat(int Count)
    {
        if (Count > Cards.Count)
            Count = Cards.Count;
        for(int i=0;i < Count;i++)
        {
            
        }
    }
    //弃牌（写在每个Card里面的usethis里）

}
