using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static int gridSize = 1;

    //coordinate convert
    //hex: q,r,s(q+r+s=0)
    //rect: x,y,z
    public static Vector3 HexCoordToRectCoord(Vector2 hexPos, Vector3 origin, float hexSize = 1f)
    {
        /* float horizonalSpacing = (3 / 2f) * hexSize;
         float verticalSpacing = 2 * 0.86602f * hexSize;*/
        float q = hexPos.x, r = hexPos.y, s = 1 - q - r, h = origin.y;
        Vector3 qBase = new Vector3(1, h, 0);
        Vector3 sBase = new Vector3(-0.5f, h, 0.866f);
        Vector3 rBase = new Vector3(-0.5f, h, -0.866f);
        Vector3 convertedPos = hexSize * (q * qBase + r * rBase + s * sBase) + origin;
        return convertedPos;
        //generate a function which adds two values

    }
}
