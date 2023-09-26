using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_dir : MonoBehaviour
{
    public bool isMove;
    private void Start()
    {
        isMove = GeneralData.instance.generalData.isMove;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //获取鼠标位置
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPos;
            bool isHit = Physics.Raycast(ray, out hitPos ,10,LayerMask.GetMask("Grid"));

            if(isHit && hitPos.collider.tag == "Grid")//写地块的基属性
            {
                isMove= true;
            }
            else
            {
                isMove= false;
            }
        }

        if(isMove)
        {
            PlayerToTarget();
        }
    }
    //角色前进方向
    void PlayerToTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitPos;
        bool isHit = Physics.Raycast(ray, out hitPos,10, LayerMask.GetMask("Grid"));
        if (isHit && hitPos.collider.tag == "Grid")
        {
            Grid gridToChoose = hitPos.collider.GetComponent<Grid>();
            if(gridToChoose != null && Input.GetMouseButtonDown(0))
            {
                Debug.Log(gridToChoose.transform.position);
                hitPos.transform.position = gridToChoose.transform.position;
                Debug.Log(hitPos.transform.position);
                LookAtTarget(hitPos.point);
            }
        }
    }
    //角色朝向
    void LookAtTarget(Vector3 tarPos)
    {
        //GeneralData.instance.generalData.targetPos = tarPos;
        //GeneralData.instance.generalData.targetPos = new Vector3(tarPos.x,transform.position.y,tarPos.z);
        GeneralData.instance.generalData.GetPos(new Vector3(tarPos.x, transform.position.y, tarPos.z));
        this.transform.LookAt(GeneralData.instance.generalData.targetPos);
        Debug.Log("dir"+GeneralData.instance.generalData.targetPos);
    }


}
