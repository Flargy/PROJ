using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderPath : MonoBehaviour
{
    [SerializeField] private GameObject boxDisplay = null;
    [SerializeField] private float initialVelocity = 6.0f;
    [SerializeField] private float timeResolution = 0.1f;
    [SerializeField] private float maxTime = 1.6f;
    [SerializeField] private LayerMask hitLayer = -1;

    private LineRenderer lr;
    private GameObject boxDisplayInstance = null;
    private bool isLifted = false;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
    }

    public void SwapLifted()
    {
        isLifted = !isLifted;
        lr.enabled = isLifted;
        if(boxDisplayInstance != null)
        {
            Destroy(boxDisplayInstance);
        }
    }

    private void Update()
    {
        if(isLifted == true) { 
        Vector3 velocityVector = transform.forward * initialVelocity;


        int index = 0;

        Vector3 currentPosition = transform.position;
        RaycastHit hit;

            for (float t = 0.0f; t <= maxTime; t += timeResolution)
            {
                Debug.Log("counter");
                lr.positionCount = index + 1;
                lr.SetPosition(index, currentPosition);
                if (Physics.Raycast(currentPosition, velocityVector, out hit, 1.0f, hitLayer))
                {
                    lr.positionCount = index + 2;
                    lr.SetPosition(index + 1, hit.point);

                    if (boxDisplay != null)
                    {
                        if (boxDisplayInstance != null)
                        {
                            boxDisplayInstance.transform.position = hit.point + Vector3.up * 0.2f;
                            boxDisplayInstance.transform.rotation = transform.rotation;
                        }
                        else
                        {
                            boxDisplayInstance = Instantiate(boxDisplay, hit.point + Vector3.up * 0.2f, Quaternion.identity) as GameObject;
                        }
                    }
                    break;
                }
                
                currentPosition += velocityVector * timeResolution;
                velocityVector += Physics.gravity * timeResolution;
                index++;
            }
            if(Physics.Raycast(currentPosition, velocityVector, 1.0f, hitLayer) == false && boxDisplayInstance != null)
            {
                Destroy(boxDisplayInstance);
            }
        }
    }
}
