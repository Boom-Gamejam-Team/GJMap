using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Scripting;


public class EventGrid : Grid
{
    public List<string> parameter = new();
    public UnityEvent eventGridEventHandler;
    protected override void Awake()
    {
        base.Awake();
    }

    public EventGrid(GridType _type, Vector2 _hexPos, int _id) : base(_type, _hexPos, _id)
    {

    }
    public override void OnEnter()
    {
        base.OnEnter();
        eventGridEventHandler.Invoke();
    }

}
