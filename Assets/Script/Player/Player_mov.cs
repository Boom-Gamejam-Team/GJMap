using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_mov : MonoBehaviour
{
    public float speed = 1;
    private BoxCollider playerCol;
    void Start()
    {
        playerCol= GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //计算目标与现在距离差值
        float distance = Vector3.Distance(GeneralData.instance.generalData.targetPos,transform.position);
        if (distance > 0.1f)
        {
            Move(GeneralData.instance.generalData.targetPos,speed);
            Debug.Log(GeneralData.instance.generalData.targetPos);
        }
        
        
    }
    void Move(Vector3 tarPos,float speed)
    {
        this.transform.position = Vector3.MoveTowards(transform.position,tarPos,speed*Time.deltaTime);
    }
}
