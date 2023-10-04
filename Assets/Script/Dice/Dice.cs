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
    public Text pointText;//debug
    public static void DiceInit()//初始化点数
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
    public void EndThrow()
    {
        Data.isThrow = false;
        diceUse = true;
    }
    public int GetPoint()
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
    private void Update()//debug
    {
        pointText.text = GetPoint().ToString();
    }
}
