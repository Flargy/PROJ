using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrtographicCamera : MonoBehaviour
{
    [SerializeField] private float delayTime = 0.2f;
    [SerializeField] private float screenOffset = 4.0f;
    [SerializeField] private float minimumSize = 5.0f;
    [SerializeField] private Transform[] players = null;
    [SerializeField] private Vector3 cameraOffset = Vector3.zero;

    private Camera cameraReference = null;
    private float zoomSpeed = 0.0f;
    private Vector3 movementvelocity = Vector3.zero;
    private Vector3 desiredPosition = Vector3.zero;

    private void Awake()
    {
        cameraReference = GetComponentInChildren<Camera>();
    }

    private void LateUpdate()
    {
        Move();
        Zoom();
    }

    private void Move()
    {
        FindAveragePosition();

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition + cameraOffset, ref movementvelocity, delayTime);
    }

    private void FindAveragePosition()
    {
        Vector3 averagePosition = new Vector3();
        int numberOfTargets = 0;

        foreach(Transform target in players)
        {
            if (!target.gameObject.activeSelf)
            {
                continue;
            }
            averagePosition += target.position;
            numberOfTargets++;
        }

        if(numberOfTargets > 0)
        {
            averagePosition /= numberOfTargets;
        }
        averagePosition.y = transform.position.y;
        desiredPosition = averagePosition;
    }

    private void Zoom()
    {
        float requiredSize = FindRequiredSize();
        cameraReference.orthographicSize = Mathf.SmoothDamp(cameraReference.orthographicSize, requiredSize, ref zoomSpeed, delayTime);
    }

    private float FindRequiredSize()
    {
        Vector3 desiredLocalPosition = transform.InverseTransformPoint(desiredPosition);

        float size = 0.0f;

        foreach(Transform target in players)
        {
            if (!target.gameObject.activeSelf)
            {
                continue;
            }
            Vector3 targetLocalPosition = transform.InverseTransformPoint(target.position);

            Vector3 desiredPositionToTarget = new Vector3(targetLocalPosition.x, 0, targetLocalPosition.z) - desiredLocalPosition;

            size = Mathf.Max(size, Mathf.Abs(desiredPositionToTarget.z/2));
            size = Mathf.Max(size, Mathf.Abs(desiredPositionToTarget.x) / cameraReference.aspect);
        }

        size += screenOffset;

        size = Mathf.Max(size, minimumSize);

        return size;
    }

    
}
