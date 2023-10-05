using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class BagManager : MonoBehaviour
{
    public static BagManager instance;
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
    public CardItemsUI cardItems;
    public GameObject cardPosPoint;
    public GameObject itemGrid;
    public Text itemInfo;
    public Text playerMoney;

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
    //重载方法
    //往卡组背包里加东西
    public static void CreatNewItem(CardItem cardItem)
    {
        CardItemsUI cardUI = Instantiate(instance.cardItems,instance.cardPosPoint.transform);
        cardUI.cardItem = cardItem;
        cardUI.cardImage.sprite = cardItem.itemImage;
        cardUI.cardCost = cardItem.cardCost;
        cardUI.cardGroup = cardItem.cardGroup;
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
            CreatNewItem(instance.myBag.cardList[i]);
        }
    }
    //生成物体
    /*public static GameObject InstantiateObj(Item item)
    {

    }*/
    
}
