﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectedLibraryPlatforms : AffectedObject
{
    [SerializeField] private Vector3 startPosition = Vector3.zero;
    [SerializeField] private Transform endPosition = null;
    [SerializeField] private PhysicMaterial startMaterial, movementMaterial = null;

    private float lerpTime = 0;
    private float t = 0;
    private Vector3 goToPosition = Vector3.zero;
    private Vector3 goFromPosition = Vector3.zero;
    private Vector3 endPos = Vector3.zero;
    private Rigidbody rb = null;
    private Coroutine movement = null;
    private bool coroutineIsRunning = false;
    private bool activatedFirstTime = false;
    private BoxCollider[] boxes;

    public override void ExecuteAction()
    {
        if (coroutineIsRunning == true)
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
        endPos = endPosition.position;
        goToPosition = endPos;
        goFromPosition = startPosition;
        boxes = rb.gameObject.GetComponents<BoxCollider>();

    }

    private IEnumerator ChangePosition()
    {
        if(activatedFirstTime == false)
        {
            startPosition = rb.transform.position;
            activatedFirstTime = true;
        }
        goFromPosition = transform.position;
        foreach (BoxCollider box in boxes)
        {
            box.material = movementMaterial;
        }
        coroutineIsRunning = true;
        while (lerpTime < actionDuration)
        {
            t += Time.deltaTime / actionDuration;
            //transform.position = Vector3.Lerp(goFromPosition, goToPosition, t);
            rb.MovePosition(Vector3.Lerp(goFromPosition, goToPosition, t));
            lerpTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        SwapLocationValues();
        foreach (BoxCollider box in boxes)
        {
            box.material = startMaterial;
        }

        coroutineIsRunning = false;

    }

    private void SwapLocationValues()
    {
        t = 0.0f;
        lerpTime = 0.0f;
        goFromPosition = rb.transform.position;
        if (goToPosition == endPos)
        {
            goToPosition = startPosition;
        }
        else
        {
            goToPosition = endPos;
        }
    }
}
