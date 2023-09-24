using System.Collections;
using UnityEngine;

public class CharacterAction
{
    public float MoveSpeed = 10f;
    static float Dis = 2f;
    public bool isArrivedObj = false;
    public bool isArrivedPos = false;
    public bool isOVER = true;
    public bool Started = false;
    public bool isWating = false;//是否在等待
    public void MoveToObj(GameObject MovedObject, GameObject TargetObject)
    {
        Vector3 TargetPoisition = TargetObject.transform.position;
        if (Vector3.Distance(TargetPoisition, MovedObject.transform.position) > Dis && !isArrivedObj)
        {
            //MovedObject.transform.Translate((TargetPoisition - MovedObject.transform.position).normalized*Time.deltaTime*2f);
            MovedObject.transform.position = Vector3.MoveTowards(MovedObject.transform.position, TargetPoisition, MoveSpeed * Time.deltaTime);
            MovedObject.transform.LookAt(TargetPoisition);
            //对TaegetObjcet物体操作
        }
        else isArrivedObj = true;
    }
    public void MoveToPosition(GameObject MovedObject, Vector3 TargetPosition, float Distance)
    {
        if (!isArrivedPos && Vector3.Distance(TargetPosition, MovedObject.transform.position) > Distance)
        {
            //MovedObject.transform.LookAt(TargetPosition);
            //MovedObject.transform.Translate(-(TargetPoisition - MovedObject.transform.position).normalized*Time.deltaTime*2f);
            MovedObject.transform.position = Vector3.MoveTowards(MovedObject.transform.position, TargetPosition, MoveSpeed * Time.deltaTime);
        }
        else isArrivedPos = true;
    }
    public IEnumerator MoveTo(GameObject MoveObject, Vector3 TargetPosition, bool WantToDo, float StayTime, float Distance)
    {
        if (!isOVER)
        {
            MoveToPosition(MoveObject, TargetPosition, Distance);
        }
        if (isArrivedObj || isArrivedPos)
        {
            if (WantToDo)
            {

            }
            isWating = true;
            yield return new WaitForSeconds(StayTime);
            isOVER = true;
            isWating = false;
        }
        if (isOVER)
        {
            yield break;
        }
    }
    public void ItemUse()
    {

    }
}
