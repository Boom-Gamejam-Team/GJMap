using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MapEditor : Singleton<MapEditor>
{

    [Header("Grid prefabs")]
    public GameObject gridObj;
    public GameObject gridDummyObj;
    public GameObject gridDummySelectedObj;
    public Transform gridParent;

    [Header("Editor options")]
    public bool isEditorEnabled;
    public bool isGenerateGridGroup;
    public int gridGroupSize = 3;
    public LayerMask rayLayerMask;

    [Header("Level options")]
    public bool isAutoFindLevel;
    public Level currentLevel;

    [HideInInspector]
    public List<Grid> gridList;

    //UI
    [Header("UI")]
    public RectTransform panel;
    public Text idTxt;
    public Text posTxt;
    public Dropdown typeDropdown;
    public Text isSpawnPointTxt;

    private Grid currentSelectedGrid;
    private GameObject gridDummyObjInstance;
    private GameObject gridDummySelectedObjInstance;
    private new void Awake()
    {
        base.Awake();
        gridDummyObjInstance = Instantiate(gridDummyObj);
        gridDummyObjInstance.SetActive(false);
        gridDummySelectedObjInstance = Instantiate(gridDummySelectedObj);
        gridDummySelectedObjInstance.SetActive(false);
        if (isAutoFindLevel)
        {
            currentLevel = FindObjectOfType<Level>();
        }
    }

    private void Start()
    {
        if (isGenerateGridGroup)
            GenerateRegularGridGroup(Vector3.zero, gridGroupSize);
    }

    private void Update()
    {
        if (isEditorEnabled)
        {
            GridSelection();
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.X))
            {
                DeleteGrid();
            }
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

    void GridSelection()
    {
        // if (Input.mousePosition.x > Screen.width - 2 * (Screen.width - panel.position.x) &&
        //     Input.mousePosition.y > Screen.height - 2 * (Screen.height - panel.position.y))
        //     return;


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (!EventSystem.current.IsPointerOverGameObject())
            if (Physics.Raycast(ray, out hit, 1000, rayLayerMask))
            {
                Grid castedGrid = hit.collider.GetComponent<Grid>();
                if (castedGrid == null) return;
                EnableDummyGrid(castedGrid.transform.position);
                if (Input.GetMouseButton(0))
                {
                    SelectGrid(castedGrid);
                }
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    UnselectAllGrid();
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
        ChangeUIElement();
    }

    void UnselectAllGrid()
    {
        currentSelectedGrid = null;
        DisableDummyGrid(true);
    }

    //UI
    void ChangeUIElement()
    {
        idTxt.text = currentSelectedGrid.id.ToString();
        posTxt.text = "q: " + currentSelectedGrid.hexPos.x + " r: " + currentSelectedGrid.hexPos.y + " s: " +
            (1 - currentSelectedGrid.hexPos.x - currentSelectedGrid.hexPos.y);
        typeDropdown.value = (int)currentSelectedGrid.type;
        isSpawnPointTxt.text = currentSelectedGrid.hexPos == currentLevel.spawnPos ? "Spawn Point" : "";
    }

    public void SubmitGridChange()
    {
        if (currentSelectedGrid == null)
        {
            Debug.Log("No grid selected");
            return;
        }
        currentSelectedGrid.ChangeGridType((GridType)typeDropdown.value);
    }
    public void DeleteGrid()
    {
        if (currentSelectedGrid == null)
        {
            Debug.Log("No grid selected");
            return;
        }
        List<Grid> currentNeighborGrids = new List<Grid>();
        foreach (var i in currentSelectedGrid.neighborGrids)
        {
            currentNeighborGrids.Add(i);
        }
        foreach (var i in currentNeighborGrids)
        {
            i.neighborGrids.Remove(currentSelectedGrid);
        }
        Destroy(currentSelectedGrid.gameObject);
        gridList.Remove(currentSelectedGrid);
        UnselectAllGrid();
    }

    public void SetSpawnPoint()
    {
        if (currentSelectedGrid == null)
        {
            Debug.Log("No grid selected");
            return;
        }
        currentLevel.spawnPos = currentSelectedGrid.hexPos;
        ChangeUIElement();
    }
}
