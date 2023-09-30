using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class GeneralData : MonoBehaviour
{
    //����ģʽ
    public static GeneralData instance;
    private void Awake()
    {
        instance = this;
    }
    public Data generalData = new Data();
    public List<Item> itemList = new List<Item>();


}
//���ݴ洢
public class Data
{

    //���ݴ洢
    public float tValue;//��Űֵ
    public List<Card> cards;//����
    public string terType;//��������
    public float playerHealth;//���Ѫ��
    public int pHAccount = 3;//���������
    public int money;//��ҽ�Ǯ
    public bool isMove = false;//����Ƿ�����ƶ�
    public Vector3 targetPos;//��¼��ҽ�Ҫ�ƶ���λ����Ϣ
    //�����ɫ����



    //��ȡĿ��λ��
    public void GetPos(Vector3 tarPos)
    {
        this.targetPos = tarPos;
    }
}
