using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    static public GameObject This_Card;//这个是被选择的卡牌
    public bool IsInitialed;
    public string CardName;
    public string CardType;
    public string CardDescription;
    public string CardTitle;
    public bool IsUsed;
    public Vector2 InitialPos;
    public virtual void UseThis()
    {

    }
    public virtual void SetMark(bool mark)
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(This_Card==null)
        transform.localScale = new Vector3(1.5f, 1.5f, 1);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if(This_Card==null)
        transform.localScale = new Vector3(1f, 1f, 1);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            This_Card = eventData.pointerClick;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        InitialPos=transform.GetComponent<RectTransform>().anchoredPosition;
    }
    public void OnDrag(PointerEventData eventData)
    {

    }
    public void OnEndDrag(PointerEventData eventData)
    {

    }

    void Update()
    {
            if (Input.GetMouseButtonDown(1))
            {
            Debug.Log(This_Card.name);
            This_Card = null;
            transform.localScale = new Vector3(1f, 1f, 1);
            }
    }
}
