using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditor : MonoBehaviour
{
    public GameObject gridObj;
    private void Start()
    {
        GenerateRegularGridGroup(Vector3.zero, 10);
    }

    void GenerateRegularGridGroup(Vector3 origin, int size)
    {
        for (int q = -size; q <= size; q++)
        {
            for (int r = -size; r <= size; r++)
            {
                if (q <= 0 && r >= -size - q && r <= size || q >= 0 && r >= -size && r <= size - q)
                    Instantiate(gridObj, Utility.HexCoordToRectCoord(new Vector2(q, r), origin), Quaternion.identity);
            }
        }
    }
}
