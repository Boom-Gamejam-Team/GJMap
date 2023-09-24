using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

public class BezierCurve 
{
  public Vector3[] points;

    public BezierCurve()
    {
        points = new Vector3[4];
    }
    
    public BezierCurve(Vector3[ ] Points)
    {
        this.points = Points;
    }

    public Vector3 StartPosition
    {
        get { return points[0]; }      
    }
    public Vector3 EndPosition
    {
        get { return points[1]; }
    }
    public Vector3 GetSegment(float Time)
    {
        Time=Mathf.Clamp01(Time);
        float time = 1 - Time;
        return (time * time * time * points[0])
                + (3 * time * time * Time * points[1])
                + (3 * time * Time * Time * points[2])
                + (3 * Time * Time * Time * points[3]);
    }

    public Vector3[] GetSeagments(int Subdivisions)
    {
        Vector3[] segments = new Vector3[Subdivisions];

        float time;
        for(int i=0; i < Subdivisions; i++)
        {
            time = (float)i / Subdivisions;
            segments[i] = GetSegment(time);
        }
        return segments;
    }
}
