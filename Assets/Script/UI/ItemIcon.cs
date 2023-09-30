using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ItemIcon : MonoBehaviour
{
    public void ChangeIcon(Sprite sprite)
    {
        GetComponent<Image>().sprite = sprite;
    }
}
