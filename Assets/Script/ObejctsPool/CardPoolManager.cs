using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardPoolManager:MonoBehaviour
{
    static Dictionary<GameObject,Pool> dictionary;

    [SerializeField] Pool[] cardPools;

    private void Start()
    {
        dictionary = new Dictionary<GameObject,Pool>();
        Initialize(cardPools);
    }
    void Initialize(Pool[] pools)
    {
        foreach (var pool in pools)
        {
#if UNITY_EDITOR
            if (dictionary.ContainsKey(pool.Prefab))
            {
                Debug.LogWarning("包含重名对象");
                continue;
            }
#endif
            dictionary.Add(pool.Prefab, pool);

            //将子类对象放置父类管理
            Transform cardPoolsParent = new GameObject("Pool"+pool.Prefab.name).transform;
            cardPoolsParent.parent = transform;

            pool.Initialize(cardPoolsParent);
        }
    }

    //生成实例化
    public static GameObject Release(GameObject obj)
    {
#if UNITY_EDITOR
        if (!dictionary.ContainsKey(obj))
        {
            Debug.LogError("未包含该物体");
            return null;
        }
#endif
        return dictionary[obj].PrepareObj();
    }
    //重载方法
    //需要固定位置生成
    public static GameObject Release(GameObject obj,Vector3 pos)
    {
#if UNITY_EDITOR
        if (!dictionary.ContainsKey(obj))
        {
            Debug.LogError("未包含该物体");
            return null;
        }
#endif
        return dictionary[obj].PrepareObj(pos);
    }

}
[System.Serializable]
public class Pool
{

    public GameObject Prefab => prefab;

    Transform parent;//将子类复制体管理到父类
    Queue<GameObject> queue;

    [SerializeField]
    GameObject prefab;//预制件放置
    [SerializeField]
    int cardSize = 1;//每个卡组每个种类最大存放数

    //生成备用对象并禁用
    GameObject PrefabCol()
    {
        var clone = GameObject.Instantiate(prefab,parent);
        clone.SetActive(false);
        return clone;
    }
    //对象入队
    public void Initialize(Transform parent)
    {
        queue = new Queue<GameObject>();
        //最大存放数
        this.parent = parent;
        for (int i = 0; i < cardSize; i++)
        {
            queue.Enqueue(PrefabCol());
        }
    }
    //取出可用对象
    GameObject AvailableObj()
    {
        GameObject availableObj = null;
        if (queue.Count > 0 && !queue.Peek())
        {
            availableObj = queue.Dequeue();
        }
        else
        {
            availableObj = PrefabCol();
        }
        queue.Enqueue(availableObj);//返回对象池
        return availableObj;
    }
    //启用可用对象
    public GameObject PrepareObj()
    {
        GameObject prepareObj = AvailableObj();
        prepareObj.SetActive(true);
        return prepareObj;
    }
    //以下为重载PrepareObj方法
    //当需要固定位置生成时
    public GameObject PrepareObj(Vector3 Pos)
    {
        GameObject prepareObj = AvailableObj();
        prepareObj.SetActive(true);
        prepareObj.transform.position = Pos;
        return prepareObj;
    }
    
}
