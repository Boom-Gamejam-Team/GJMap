using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_dir : MonoBehaviour
{
    GeneralData generalData;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //��ȡ���λ��
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPos;
            bool isHit = Physics.Raycast(ray, out hitPos);

            if(isHit && hitPos.collider.tag == "")//д�ؿ�Ļ�����
            {
                generalData.isMove= true;
            }
            else
            {
                generalData.isMove= false;
            }
        }

        if(generalData.isMove)
        {
            PlayerToTarget();
        }
    }
    //��ɫǰ������
    void PlayerToTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitPos;
        bool isHit = Physics.Raycast(ray, out hitPos);
        if (isHit && hitPos.collider.tag == "")
        {
            LookAtTarget(hitPos.point);
        }
    }
    //��ɫ����
    void LookAtTarget(Vector3 tarPos)
    {
        generalData.targetPos = tarPos;
        generalData.targetPos = new Vector3(tarPos.x,transform.position.y,tarPos.z);
        this.transform.LookAt(generalData.targetPos);
    }


}
