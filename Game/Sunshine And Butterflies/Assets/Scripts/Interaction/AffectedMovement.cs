using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AffectedMovement : AffectedObject
{
    [SerializeField] private Vector3 startPosition = Vector3.zero;
    [SerializeField] private Transform endPosition = null;
    [SerializeField] private PhysicMaterial startMaterial, movementMaterial = null;

    private float lerpTime = 0;
    private float t = 0;
    private Vector3 goToPosition = Vector3.zero;
    private Vector3 goFromPosition = Vector3.zero;
    private Rigidbody rb = null;
    private Coroutine movement = null;
    private bool coroutineIsRunning = false;
    private BoxCollider box = null;

    public override void ExecuteAction()
    {
        if(coroutineIsRunning == true)
        {
            StopCoroutine(movement);
            SwapLocationValues();
            coroutineIsRunning = false;
        }
        movement = StartCoroutine(ChangePosition());
    }

    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        startPosition = rb.transform.position;
        goToPosition = endPosition.position;
        goFromPosition = startPosition;
        try{

            box = rb.gameObject.GetComponent<BoxCollider>();
        }
        catch(Exception e)
        {

        }
    }

    private IEnumerator ChangePosition()
    {
        box.material = movementMaterial;
        coroutineIsRunning = true;
        while(lerpTime < actionDuration)
        {
            t += Time.deltaTime / actionDuration;
            //transform.position = Vector3.Lerp(goFromPosition, goToPosition, t);
            rb.MovePosition(Vector3.Lerp(goFromPosition, goToPosition, t));
            lerpTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        SwapLocationValues();
        box.material = startMaterial;
        
        coroutineIsRunning = false;

    }

    private void SwapLocationValues()
    {
        t = 0.0f;
        lerpTime = 0.0f;
        goFromPosition = rb.transform.position;
        if (goToPosition == endPosition.position)
        {
            goToPosition = startPosition;
        }
        else
        {
            goToPosition = endPosition.position;
        }
    }

    
}
