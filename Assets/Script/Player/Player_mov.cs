using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_mov : MonoBehaviour
{
    public float speed = 1;
    public GameObject myBag;
    public float maxDis;
    public Dice dice = new Dice();



    bool isOpen = false;//���������

    private BoxCollider playerCol;
    void Start()
    {
        myBag = GameObject.Find("Bag");
        myBag.SetActive(isOpen);
        playerCol = GetComponent<BoxCollider>();
        GeneralData.instance.generalData.moveTargetGrid = null;
        GeneralData.instance.generalData.targetPos = new Vector3(transform.position.x, (float)0.8, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //����Ŀ�������ھ����ֵ
        float distance = Vector3.Distance(GeneralData.instance.generalData.targetPos, transform.position);

        //״̬�л�
        if (distance > maxDis)
        {
            GeneralData.instance.generalData.isPlayerMoving = false;
            GeneralData.instance.generalData.moveTargetGrid = null;
        }

        if (distance < 0.01f && GeneralData.instance.generalData.isPlayerMoving)
        {
            GeneralData.instance.generalData.isPlayerMoving = false;
            //dice.diceUse = false;
            if (GeneralData.instance.generalData.moveTargetGrid != null)
            {
                GeneralData.instance.generalData.moveTargetGrid.OnEnter();
            }
        }

        //�ж�״̬��ʵ��
        if (GeneralData.instance.generalData.isPlayerMoving)
            Move(GeneralData.instance.generalData.targetPos, speed);

        //�򿪱���
        OpenBag();

        BagManager.instance.playerMoney.text = "Money:" + GeneralData.instance.generalData.playerMoney.ToString();
    }
    void Move(Vector3 tarPos, float speed)
    {
        GeneralData.instance.generalData.isPlayerMoving = true;
        this.transform.position = Vector3.MoveTowards(transform.position, tarPos, speed * Time.deltaTime);
        GeneralData.instance.generalData.isMove = false;
    }
    void OpenBag()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;
            myBag.SetActive(isOpen);
        }
    }
}
