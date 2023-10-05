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

    public Inventory myBag;//BagMaterial���
    public ItemBag itemBagPrefab;//Prefab���
    public CardItemsUI cardItems;
    public GameObject cardPosPoint;
    public GameObject itemGrid;
    public Text itemInfo;
    public Text playerMoney;

    //�����Ʒ����
    public static void UpdateInfo(string info)
    {
        instance.itemInfo.text = info;
    }
    //��������Ӷ���
    public static void CreatNewItem(Item item)
    {
        ItemBag bag = Instantiate(instance.itemBagPrefab,instance.itemGrid.transform);
        bag.item = item;
        bag.image.sprite = item.itemImage;
        bag.itemNum.text = item.itemCount.ToString();
    }
    //���ط���
    //�����鱳����Ӷ���
    public static void CreatNewItem(CardItem cardItem)
    {
        CardItemsUI cardUI = Instantiate(instance.cardItems,instance.cardPosPoint.transform);
        cardUI.cardItem = cardItem;
        cardUI.cardImage.sprite = cardItem.itemImage;
        cardUI.cardCost = cardItem.cardCost;
        cardUI.cardGroup = cardItem.cardGroup;
    }
    //ˢ����Ʒ����
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
    //��������
    /*public static GameObject InstantiateObj(Item item)
    {

    }*/
    
}
