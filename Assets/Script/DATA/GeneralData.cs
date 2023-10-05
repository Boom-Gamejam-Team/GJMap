using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class GeneralData : MonoBehaviour
{
    //����ģʽ
    public static GeneralData instance;
    private void Awake()
    {
        instance = this;
    }
    public Data generalData = new Data();

    //Grid consts
    //grid obj reference list
    //index 0: empty grid
    //index 1: obstacle grid
    //index 2: enemy grid
    //index 3: shop grid
    //index 4: event grid
    //index 5: money grid
    public List<GameObject> gridObjList;

}
//���ݴ洢
[System.Serializable]
public class Data
{

    //���ݴ洢
    public float tValue = 100;//��Űֵ
    public List<Card> cards;//����
    public string terType;//��������
    public float playerHealth;//���Ѫ��
    public int pHAccount = 3;//���������
    public int playerMoney;//��ҽ�Ǯ
    public bool isMove = false;//����Ƿ�����ƶ�
    public bool isPlayerMoving = false;//�ƶ�״̬������
    public Grid moveTargetGrid;//��ҽ�Ҫ�ƶ����ĸ���
    public static bool isThrow = true;
    public Vector3 targetPos;//��¼��ҽ�Ҫ�ƶ���λ����Ϣ
    //�����ɫ����



    //��ȡĿ��λ��
    public void GetPos(Vector3 tarPos)
    {
        this.targetPos = tarPos;
    }
    //��Űֵ�ı�
    //��Űֵ����
    public void tValueIncrease(float damage)
    {
        tValue+= damage;
    }
    //��Űֵ����
    public void tValueDecrease(float damage)
    {
        tValue-= damage;
    }

}
