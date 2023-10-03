using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_dir : MonoBehaviour
{
    public bool isMove;

    Vector3 origin = Vector3.zero;
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
            bool isHit = Physics.Raycast(ray, out hitPos, 1000, LayerMask.GetMask("Grid"));
            if (isHit && hitPos.collider.tag == "Grid" && !EventSystem.current.IsPointerOverGameObject())//写地块的基属性
            {
                Grid hitGrid = hitPos.collider.GetComponent<Grid>();
                if (hitGrid.type != GridType.OBSTACLE)
                {
                    GeneralData.instance.generalData.isPlayerMoving = isMove = true;
                    GeneralData.instance.generalData.moveTargetGrid = hitGrid;
                }
            }
            else
            {
                isMove = false;
            }
        }

        if (isMove)
        {
            PlayerToTarget();
        }
    }
    //角色前进方向
    void PlayerToTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitPos;
        bool isHit = Physics.Raycast(ray, out hitPos, 1000, LayerMask.GetMask("Grid"));
        if (isHit && hitPos.collider.tag == "Grid" && !EventSystem.current.IsPointerOverGameObject())
        {
            Grid gridToChoose = hitPos.collider.GetComponent<Grid>();
            if (gridToChoose != null && Input.GetMouseButtonDown(0))
            {
                //获取地块中心位置
                Vector3 mapPos = Utility.HexCoordToRectCoord(gridToChoose.hexPos, origin);
                //Debug.Log(gridToChoose.transform.position);
                hitPos.transform.position = mapPos;
                //Debug.Log(hitPos.transform.position);
                LookAtTarget(mapPos);

                GeneralData.instance.generalData.targetPos = new Vector3(mapPos.x, this.transform.position.y, mapPos.z);
            }
        }
    }
    //角色朝向
    void LookAtTarget(Vector3 tarPos)
    {

        GeneralData.instance.generalData.GetPos(new Vector3(tarPos.x, transform.position.y, tarPos.z));
        this.transform.LookAt(GeneralData.instance.generalData.targetPos);
        //Debug.Log("dir"+GeneralData.instance.generalData.targetPos);
    }


}
