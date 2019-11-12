using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchArcRenderer : MonoBehaviour
{
     private LineRenderer lr;

    [SerializeField] private float velocity = 0;
    [SerializeField] private float angle = 0;
    [SerializeField] private int resolution = 0;

    private float g = 0; //force of gravity on y axis
    private float radianAngle = 0;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        g = Mathf.Abs(Physics.gravity.y);
    }

    private void Start()
    {
        RenderArc();
    }

    private void LateUpdate()
    {
        RenderArc();
    }

    //populating the LineRenderer with the correct settings
    private void RenderArc()
    {
        lr.positionCount = resolution + 1;
        lr.SetPositions(CalculateArcArray());
    }

    //create an array of vector3 positions for the arc
    private Vector3[] CalculateArcArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];

        radianAngle = Mathf.Deg2Rad * angle;
        float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / g;

        for(int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CalculatePoint(t, maxDistance);
        }
        return arcArray;
    }

    //calculate height and distance of each vertex
    private Vector3 CalculatePoint(float t, float maxDistance)
    {
        float x = t * maxDistance;
        float y = x * Mathf.Tan(radianAngle) - ((g * x * x) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
        return transform.localRotation * new Vector3(0, y, x) + transform.position;
        
    }
}
