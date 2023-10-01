using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_mov : MonoBehaviour
{
    public float speed = 1;
    public GameObject myBag;
    public float maxDis;

    bool isOpen = false;//背包打开与否

    private BoxCollider playerCol;
    void Start()
    {
        myBag = GameObject.Find("Bag");
        myBag.SetActive(isOpen);
        playerCol= GetComponent<BoxCollider>();
        GeneralData.instance.generalData.targetPos = new Vector3(transform.position.x, (float)0.8,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //计算目标与现在距离差值
        float distance = Vector3.Distance(GeneralData.instance.generalData.targetPos,transform.position);
        if (distance > 0.1f && distance<maxDis)
        {
            Move(GeneralData.instance.generalData.targetPos,speed);
            //Debug.Log("mov"+GeneralData.instance.generalData.targetPos);
        }

        //打开背包
        OpenBag();
    }
    void Move(Vector3 tarPos,float speed)
    {
        this.transform.position = Vector3.MoveTowards(transform.position,tarPos,speed*Time.deltaTime);
        GeneralData.instance.generalData.isMove = false;
    }
    void OpenBag()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;
            myBag.SetActive(isOpen);
        }
    }
}
