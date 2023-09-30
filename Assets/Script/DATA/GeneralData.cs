using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class GeneralData : MonoBehaviour
{
    //单例模式
    public static GeneralData instance;
    private void Awake()
    {
        instance = this;
    }
    public Data generalData = new Data();
    public List<Item> itemList = new List<Item>();


}
//数据存储
public class Data
{

    //数据存储
    public float tValue;//暴虐值
    public List<Card> cards;//卡组
    public string terType;//地形类型
    public float playerHealth;//玩家血量
    public int pHAccount = 3;//玩家生命数
    public int money;//玩家金钱
    public bool isMove = false;//玩家是否可以移动
    public Vector3 targetPos;//记录玩家将要移动的位置信息
    //具体角色数据



    //获取目标位置
    public void GetPos(Vector3 tarPos)
    {
        this.targetPos = tarPos;
    }
}
