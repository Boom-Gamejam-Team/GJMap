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
    public static void DiceInit()//初始化骰子
    {
        point = 0;
    }
    public static void Upgrade()//增加骰子上限
    {
        maxPoint += 2;
    }
    public void Throw()//普通骰子投掷
    {
        if (Data.isThrow&&diceUse)
        {
            diceUse = false;
            point += Random.Range(1,maxPoint+1);
        }
    }
    public void DemonThrow()//恶魔骰子投掷
    {
        if (Data.isThrow && !diceUse)
        {
            point += Random.Range(1, 7);
        }
    }
    public void EndThrow()//完成投掷
    {
        Data.isThrow = false;
        diceUse = true;
    }
    public int GetPoint()//获得值
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
