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


    public Inventory myBag;//BagMaterial里的
    public ItemBag itemBagPrefab;//Prefab里的
    public GameObject itemGrid;
    public Text itemInfo;
}
