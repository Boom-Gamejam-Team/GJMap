using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice:MonoBehaviour
{
    public static int point=0;
    public static int maxPoint=6;
    public static int demonUse;
    public bool diceUse=true;
    public Text pointTxt;//Debug
    public static void DiceInit()//��ʼ������
    {
        point = 0;
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
    public void EndThrow()//���Ͷ��
    {
        Data.isThrow = false;
        diceUse = true;
    }
    public int GetPoint()//���ֵ
    {
        if (!Data.isThrow)
        {
            return point;
        }
        else
        {
            return 0;
        }
    }
    private void Update()//Debug
    {
        pointTxt.text = GetPoint().ToString();
    }
}
