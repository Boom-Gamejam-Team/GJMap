using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_mov : MonoBehaviour
{
    public float speed = 1;
    public GameObject myBag;

    bool isOpen;//���������

    private BoxCollider playerCol;
    void Start()
    {
        myBag = GameObject.Find("Bag");
        playerCol= GetComponent<BoxCollider>();
        GeneralData.instance.generalData.targetPos = new Vector3(transform.position.x, (float)0.8,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //����Ŀ�������ھ����ֵ
        float distance = Vector3.Distance(GeneralData.instance.generalData.targetPos,transform.position);
        if (distance > 0.1f)
        {
            Move(GeneralData.instance.generalData.targetPos,speed);
            //Debug.Log("mov"+GeneralData.instance.generalData.targetPos);
        }

        //�򿪱���
        OpenBag();
    }
    void Move(Vector3 tarPos,float speed)
    {
        this.transform.position = Vector3.MoveTowards(transform.position,tarPos,speed*Time.deltaTime);
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