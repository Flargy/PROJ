using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectedMovement : AffectedObject
{
    [SerializeField] private Vector3 startPosition = Vector3.zero;
    [SerializeField] private Transform endPosition = null;

    private float lerpTime = 0;
    private float t = 0;
    private Vector3 goToPosition = Vector3.zero;
    private Vector3 goFromPosition = Vector3.zero;
    private Rigidbody rb = null;

    public override void ExecuteAction()
    {
        
        StartCoroutine(ChangePosition());
    }

    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        startPosition = rb.transform.position;
        goToPosition = endPosition.position;
        goFromPosition = startPosition;
    }

    private IEnumerator ChangePosition()
    {
        while(lerpTime < actionDuration)
        {
            t += Time.deltaTime / actionDuration;
            //transform.position = Vector3.Lerp(goFromPosition, goToPosition, t);
            rb.MovePosition(Vector3.Lerp(goFromPosition, goToPosition, t));
            lerpTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        if(goFromPosition == startPosition)
        {
            goFromPosition = rb.transform.position;
            goToPosition = startPosition;
        }
        else
        {
            goToPosition = endPosition.position;
            goFromPosition = rb.transform.position;
        }
        t = 0.0f;
        lerpTime = 0.0f;
    }

    
}
