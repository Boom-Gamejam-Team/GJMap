using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GeneralData 
{
    //单例模式
    public static GeneralData generalData;

    private void Awake()
    {
        if(generalData==null)
        {
            generalData = this;
        }
    }

    //数据存储
    public float tValue;//暴虐值
    public List<Card> cards;//卡组
    public string terType;//地形类型
    public float playerHealth;//玩家血量
    public int pHAccount = 3;//玩家生命数
    //具体角色数据
}
