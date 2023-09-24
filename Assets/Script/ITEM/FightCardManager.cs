using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCardManager:MonoBehaviour
{
    public static FightCardManager instance=new FightCardManager();//����
    public List<GameObject> AllCards = new List<GameObject>();
    public List<Card> Cards = new List<Card>();//���ƶ�
    public List<Card> usedCards = new List<Card>();//���ƶ�
    // Start is called before the first frame update
    public void FightInit()//����ս��ʱ
    {
        AllCards.AddRange(Gamemanager.CardBag);
        TurnInit();
        //��������ʵ��ʱ��¼���ƣ���Ϊ���ɵĿ������岻�Ǳ����еĿ��ƣ�
    }
    public void TurnInit()//�غϿ�ʼʱϴ��
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
    
    public void CardWash(int Count)//�Ӻ���ǰ������
    {
        if (Count > usedCards.Count)
            Count = usedCards.Count;
        for(int i=0;i<Count;i++)
        {
            Cards.Add(usedCards[i]);
        }
    }
    //����
    public void CardCreat(int Count)
    {
        if (Count > Cards.Count)
            Count = Cards.Count;
        for(int i=0;i < Count;i++)
        {
            
        }
    }
    //���ƣ�д��ÿ��Card�����usethis�

}
