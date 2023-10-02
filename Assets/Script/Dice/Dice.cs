using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dice
{
    public int point;
    public static int maxPoint;
    public static void Init()
    {
        maxPoint = 6;
    }
    public static void Upgrade()
    {
        maxPoint += 2;
    }
    public int Throw()
    {
        point =(int)UnityEngine.Random.Range(1,maxPoint+1);
        return point;
    }

}
