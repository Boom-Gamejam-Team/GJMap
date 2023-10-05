using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class GeneralData : MonoBehaviour
{
    //单例模式
    public static GeneralData instance;
    private void Awake()
    {
        instance = this;
    }
    public Data generalData = new Data();

    //Grid consts
    //grid obj reference list
    //index 0: empty grid
    //index 1: obstacle grid
    //index 2: enemy grid
    //index 3: shop grid
    //index 4: event grid
    //index 5: money grid
    public List<GameObject> gridObjList;

}
//数据存储
[System.Serializable]
public class Data
{

    //数据存储
    public float tValue = 100;//暴虐值
    public List<Card> cards;//卡组
    public string terType;//地形类型
    public float playerHealth;//玩家血量
    public int pHAccount = 3;//玩家生命数
    public int playerMoney;//玩家金钱
    public bool isMove = false;//玩家是否可以移动
    public bool isPlayerMoving = false;//移动状态机变量
    public Grid moveTargetGrid;//玩家将要移动到的格子
    public static bool isThrow = true;
    public Vector3 targetPos;//记录玩家将要移动的位置信息
    //具体角色数据



    //获取目标位置
    public void GetPos(Vector3 tarPos)
    {
        this.targetPos = tarPos;
    }
    //暴虐值改变
    //暴虐值增加
    public void tValueIncrease(float damage)
    {
        tValue+= damage;
    }
    //暴虐值减少
    public void tValueDecrease(float damage)
    {
        tValue-= damage;
    }

}
