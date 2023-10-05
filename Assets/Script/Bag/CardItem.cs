using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BagMaterial", menuName = "BagMaterial/cardItem")]
public class CardItem : Item
{
    public GameObject[] cardGroup;
    public int cardCost;
}
