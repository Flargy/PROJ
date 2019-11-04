using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrtographicCamera : MonoBehaviour
{
    [SerializeField] private float delayTime = 0.2f;
    [SerializeField] private float screenOffset = 4.0f;
    [SerializeField] private float minimumSize = 5.0f;
    [SerializeField] private Transform[] players = null;

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
    }

    private void Move()
    {
        FindAveragePosition();

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref movementvelocity, delayTime);
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


}
