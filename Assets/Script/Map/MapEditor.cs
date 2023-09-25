using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditor : MonoBehaviour
{
    public GameObject gridObj;
    public GameObject gridDummyObj;
    public GameObject gridDummySelectedObj;
    public Transform gridParent;

    public bool isEditorEnabled;
    public int gridGroupSize = 3;

    public List<Grid> gridList;

    private Grid currentSelectedGrid;
    private GameObject gridDummyObjInstance;
    private GameObject gridDummySelectedObjInstance;
    private void Awake()
    {
        gridDummyObjInstance = Instantiate(gridDummyObj);
        gridDummyObjInstance.SetActive(false);
        gridDummySelectedObjInstance = Instantiate(gridDummySelectedObj);
        gridDummySelectedObjInstance.SetActive(false);
    }

    private void Start()
    {
        GenerateRegularGridGroup(Vector3.zero, gridGroupSize);
    }

    private void Update()
    {
        if (isEditorEnabled)
        {
            SelectGrid();
        }
    }

    void GenerateRegularGridGroup(Vector3 origin, int size)
    {
        int idCounter = 0;
        for (int q = -size; q <= size; q++)
        {
            for (int r = -size; r <= size; r++)
            {
                if (q <= 0 && r >= -size - q && r <= size || q >= 0 && r >= -size && r <= size - q)
                {
                    GameObject currentGrid = Instantiate(gridObj, Utility.HexCoordToRectCoord(new Vector2(q, r), origin), Quaternion.identity);
                    currentGrid.transform.parent = gridParent;
                    Grid gridComponent = currentGrid.AddComponent<Grid>();
                    gridComponent.SetAttributes(GridType.EMPTY, new Vector2(q, r), idCounter);
                    currentGrid.name += "_" + gridComponent.id;
                    gridList.Add(gridComponent);

                    idCounter++;
                }
            }
        }
        foreach (var i in gridList)
        {
            if (i != null)
                i.DetectNeighbor();
        }
    }

    void SelectGrid()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("Grid")))
        {
            Grid castedGrid = hit.collider.GetComponent<Grid>();
            if (castedGrid == null) return;
            EnableDummyGrid(castedGrid.transform.position);
            if (Input.GetMouseButton(0))
            {
                SelectGrid(castedGrid);
            }
        }
    }

    void EnableDummyGrid(Vector3 pos, bool isSelecting = false)
    {
        if (isSelecting)
        {
            gridDummySelectedObjInstance.SetActive(true);
            gridDummySelectedObjInstance.transform.position = pos;
        }
        else
        {
            gridDummyObjInstance.SetActive(true);
            gridDummyObjInstance.transform.position = pos;
        }

    }

    void DisableDummyGrid(bool isSelecting = false)
    {
        if (isSelecting)
        {
            gridDummySelectedObjInstance.SetActive(false);
        }
        else
        {
            gridDummyObjInstance.SetActive(false);
        }

    }

    void SelectGrid(Grid grid)
    {
        currentSelectedGrid = grid;
        EnableDummyGrid(grid.transform.position, true);
    }

    void unselectAllGrid()
    {
        currentSelectedGrid = null;
        DisableDummyGrid(true);
    }
}
