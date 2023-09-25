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
            //获取鼠标位置
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPos;
            bool isHit = Physics.Raycast(ray, out hitPos);

            if(isHit && hitPos.collider.tag == "")//写地块的基属性
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
    //角色前进方向
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
    //角色朝向
    void LookAtTarget(Vector3 tarPos)
    {
        generalData.targetPos = tarPos;
        generalData.targetPos = new Vector3(tarPos.x,transform.position.y,tarPos.z);
        this.transform.LookAt(generalData.targetPos);
    }


}
