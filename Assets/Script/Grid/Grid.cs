using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GridType
{
    EMPTY, OBSTACLE, ENEMY, SHOP, EVENT, MONEY
}


public class Grid : MonoBehaviour
{
    //grid type
    [HideInInspector]
    public GridType type = GridType.EMPTY;
    //grid pos (use q-r coordinate)
    public Vector2 hexPos;
    //specified grid id
    public int id;
    //a list which contains all the neighboring grids
    public List<Grid> neighborGrids;


    protected virtual void Awake()
    {
        neighborGrids = new();
    }

    public Grid(GridType _type, Vector2 _hexPos, int _id)
    {
        type = _type;
        hexPos = _hexPos;
        id = _id;
    }

    public void SetAttributes(GridType _type, Vector2 _hexPos, int _id)
    {
        type = _type;
        hexPos = _hexPos;
        id = _id;
    }

    private void Update()
    {

    }

    public void DetectNeighbor()
    {
        float rayLength = 1.2f * Utility.gridSize;
        for (int angle = 30; angle < 360 + 30; angle += 60)
        {
            float angle_rad = Mathf.PI / 180f * angle;
            Ray ray = new Ray(transform.position, new Vector3(Mathf.Cos(angle_rad), 0, Mathf.Sin(angle_rad)));
            // Debug.DrawLine(ray.origin, ray.origin + rayLength * new Vector3(Mathf.Cos(angle_rad), 0, Mathf.Sin(angle_rad)), Color.red);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, rayLength))
            {
                Debug.DrawLine(ray.origin, hit.point);
                Grid hitGrid = hit.collider.GetComponent<Grid>();
                if (hitGrid.id != id)
                {
                    neighborGrids.Add(hitGrid);
                }
            }
        }
    }

    public void ChangeGridType(GridType _type)
    {
        if (_type == type) return;
        //instantiate new grid
        GameObject newGridObj = Instantiate(GeneralData.instance.gridObjList[(int)_type], transform.position, transform.rotation);
        newGridObj.transform.parent = MapEditor.Instance.gridParent;
        Grid newGrid = _type switch
        {
            GridType.EMPTY => newGridObj.AddComponent<Grid>(),
            GridType.OBSTACLE => newGridObj.AddComponent<ObstacleGrid>(),
            GridType.ENEMY => newGridObj.AddComponent<EnemyGrid>(),
            GridType.SHOP => newGridObj.AddComponent<ShopGrid>(),
            GridType.EVENT => newGridObj.AddComponent<EventGrid>(),
            GridType.MONEY => newGridObj.AddComponent<MoneyGrid>(),
            _ => newGridObj.AddComponent<Grid>(),
        };
        //hard copy grid data
        newGrid.SetAttributes(_type, hexPos, id);
        foreach (var i in newGrid.neighborGrids)
        {
            newGrid.neighborGrids.Add(i);
        }

        //update neighboring grid data
        foreach (var i in neighborGrids)
        {
            i.neighborGrids.Remove(this);
            i.neighborGrids.Add(newGrid);
        }

        //destroy old grid
        Destroy(gameObject);
    }

    public virtual void OnEnter()
    {
        Debug.Log("Entered grid type " + type);
    }

}
