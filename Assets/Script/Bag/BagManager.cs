using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagManager : MonoBehaviour
{
    static BagManager instance;
    private void Awake()
    {
        if(instance!=null) 
            Destroy(instance);
        instance= this;
    }
    private void OnEnable()
    {
        Refresh();
        instance.itemInfo.text = string.Empty;
    }

    public Inventory myBag;//BagMaterial里的
    public ItemBag itemBagPrefab;//Prefab里的
    public GameObject itemGrid;
    public Text itemInfo;

    //添加物品描述
    public static void UpdateInfo(string info)
    {
        instance.itemInfo.text = info;
    }
    //往背包里加东西
    public static void CreatNewItem(Item item)
    {
        ItemBag bag = Instantiate(instance.itemBagPrefab,instance.itemGrid.transform);
        bag.item = item;
        bag.image.sprite = item.itemImage;
        bag.itemNum.text = item.itemCount.ToString();
    }
    //刷新物品个数
    public static void Refresh()
    {
        for(int i = 0;i<instance.itemGrid.transform.childCount;i++)
        {
            Destroy(instance.itemGrid.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < instance.myBag.bagList.Count; i++)
        {
            CreatNewItem(instance.myBag.bagList[i]);
        }
    }
}
