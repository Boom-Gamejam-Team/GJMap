using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dice
{
    public static int point=0;
    public static int maxPoint;
    public static int demonUse;
    public bool diceUse=true;
    public static void DiceInit()//��ʼ����������
    {
        maxPoint = 6;
    }
    public static void Upgrade()//������������
    {
        maxPoint += 2;
    }
    public void Throw()//��ͨ����Ͷ��
    {
        if (Data.isThrow&&diceUse)
        {
            diceUse = false;
            point += Random.Range(1,maxPoint+1);
        }
    }
    public void DemonThrow()//��ħ����Ͷ��
    {
        if (Data.isThrow && !diceUse)
        {
            point += Random.Range(1, 7);
        }
    }
    public int EndThrow()
    {
        Data.isThrow = false;
        diceUse = true;
        return point;
    }
}
