using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class GeneralData :MonoBehaviour
{
    //����ģʽ
    public static GeneralData instance;
    private void Awake()
    {
        instance = this;
    }
    public Data generalData = new Data();
    private void Start()
    {

    }
    private void Update()
    {

    }


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
    public bool isMove = false;//����Ƿ�����ƶ�
    public Vector3 targetPos;//��¼��ҽ�Ҫ�ƶ���λ����Ϣ
    //�����ɫ����
}
