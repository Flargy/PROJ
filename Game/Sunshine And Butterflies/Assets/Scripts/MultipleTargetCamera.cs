﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour
{
    [SerializeField] private List<Transform> players;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float maxZoom = 10;
    [SerializeField] private float minZoom = 30;
    [SerializeField] private float zoomLimiter = 50;

    private Bounds bound;
    private Vector3 centerPoint;
    private Vector3 newPosition;
    private Vector3 velocity;
    private float smoothTime = 0.5f;
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        Move();

    }

    private void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    private void Move()
    {
        centerPoint = GetCenterPoint();

        newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    private float GreatestDistance()
    {
        Bounds bound = new Bounds(players[0].position, Vector3.zero);
        bound.Encapsulate(players[1].position);
        return bound.size.x;
    }

    private Vector3 GetCenterPoint()
    {
        
        Bounds bound = new Bounds(players[0].position, Vector3.zero);
        bound.Encapsulate(players[1].position);
        

        return bound.center;
    }
}
