using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GeneralData 
{
    //����ģʽ
    public static GeneralData generalData;

    private void Awake()
    {
        if(generalData==null)
        {
            generalData = this;
        }
    }

    //���ݴ洢
    public float tValue;//��Űֵ
    public List<Card> cards;//����
    public string terType;//��������
    public float playerHealth;//���Ѫ��
    public int pHAccount = 3;//���������
    public bool isMove = false;//����Ƿ�����ƶ�
    public Vector3 targetPos;//��¼��ҽ�Ҫ�ƶ���λ����Ϣ
    //�����ɫ����
}
