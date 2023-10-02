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
                Debug.LogWarning("������������");
                continue;
            }
#endif
            dictionary.Add(pool.Prefab, pool);

            //�����������ø������
            Transform cardPoolsParent = new GameObject("Pool"+pool.Prefab.name).transform;
            cardPoolsParent.parent = transform;

            pool.Initialize(cardPoolsParent);
        }
    }

    //����ʵ����
    public static GameObject Release(GameObject obj)
    {
#if UNITY_EDITOR
        if (!dictionary.ContainsKey(obj))
        {
            Debug.LogError("δ����������");
            return null;
        }
#endif
        return dictionary[obj].PrepareObj();
    }
    //���ط���
    //��Ҫ�̶�λ������
    public static GameObject Release(GameObject obj,Vector3 pos)
    {
#if UNITY_EDITOR
        if (!dictionary.ContainsKey(obj))
        {
            Debug.LogError("δ����������");
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

    Transform parent;//�����ิ�����������
    Queue<GameObject> queue;

    [SerializeField]
    GameObject prefab;//Ԥ�Ƽ�����
    [SerializeField]
    int cardSize = 1;//ÿ������ÿ�������������

    //���ɱ��ö��󲢽���
    GameObject PrefabCol()
    {
        var clone = GameObject.Instantiate(prefab,parent);
        clone.SetActive(false);
        return clone;
    }
    //�������
    public void Initialize(Transform parent)
    {
        queue = new Queue<GameObject>();
        //�������
        this.parent = parent;
        for (int i = 0; i < cardSize; i++)
        {
            queue.Enqueue(PrefabCol());
        }
    }
    //ȡ�����ö���
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
        queue.Enqueue(availableObj);//���ض����
        return availableObj;
    }
    //���ÿ��ö���
    public GameObject PrepareObj()
    {
        GameObject prepareObj = AvailableObj();
        prepareObj.SetActive(true);
        return prepareObj;
    }
    //����Ϊ����PrepareObj����
    //����Ҫ�̶�λ������ʱ
    public GameObject PrepareObj(Vector3 Pos)
    {
        GameObject prepareObj = AvailableObj();
        prepareObj.SetActive(true);
        prepareObj.transform.position = Pos;
        return prepareObj;
    }
    
}
