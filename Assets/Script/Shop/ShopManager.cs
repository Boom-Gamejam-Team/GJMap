using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TradeInf
{
    public Item item;
    public int priceOffset;
    public int amount;

    public TradeInf(Item _item)
    {
        item = _item;
    }
    public TradeInf(Item _item, int _priceOffset, int _amount)
    {
        item = _item;
        priceOffset = _priceOffset;
        amount = _amount;
    }
}

public class ShopManager : Singleton<ShopManager>
{
    public GridUI itemGrid;
    public GameObject shopUI;
    public Text nameText;
    public Text valueText;
    public Text descriptionText;

    public Item currentChoosenItem;
    private int currentChoosenItemValue;
    private List<TradeInf> currentTradeList;
    public void ShowShop(List<TradeInf> tradeList)
    {
        currentTradeList = tradeList;
        //Enable shop UI or reset shop UI if it is already enabled
        if (shopUI.activeSelf == false)
        {
            shopUI.SetActive(true);
        }
        else
        {
            ResetShop();
        }
        //Add item icons to the grid of the shop UI
        foreach (var tradeInf in tradeList)
        {
            itemGrid.AddNewItemIcon(tradeInf.item);
        }
    }
    public void ResetShop()
    {
        foreach (Transform child in itemGrid.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void ChooseItem(Item item)
    {
        currentChoosenItem = item;
        nameText.text = item.itemName;
        currentChoosenItemValue = item.itemBaseValue + currentTradeList.Find(x => x.item == item).priceOffset;
        valueText.text = currentChoosenItemValue.ToString();
        descriptionText.text = item.itemDescription;
    }

    public void BuyItem()
    {
        if (currentChoosenItem == null)
        {
            Debug.Log("No item is choosen");
            return;
        }
        if (GeneralData.instance.generalData.playerMoney < currentChoosenItemValue)
        {
            Debug.Log("Not enough money");
            return;
        }
        else
        {
            GeneralData.instance.generalData.playerMoney -= currentChoosenItemValue;
            // GeneralData.instance.generalData.bagList.Add(currentChoosenItem);
            Debug.Log("Bought item: " + currentChoosenItem.itemName);
        }
    }

}
