using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectedCrushingWall : AffectedObject
{
    [SerializeField] private Vector3 startPosition = Vector3.zero;
    [SerializeField] private Transform endPosition = null;
    [SerializeField] private GameObject deathColliderHolder = null;
    [SerializeField] [Range(0.5f, 0.9f)] private float deathColliderActivationPercentage = 0.8f;

    private float lerpTime = 0;
    private float t = 0;
    private Vector3 goToPosition = Vector3.zero;
    private Vector3 goFromPosition = Vector3.zero;
    private Rigidbody rb = null;
    private Coroutine movement = null;
    private bool coroutineIsRunning = false;
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
        goToPosition = endPosition.position;
        goFromPosition = startPosition;
        boxes = rb.gameObject.GetComponents<BoxCollider>();

    }

    private IEnumerator ChangePosition()
    {
       
        coroutineIsRunning = true;
        while (lerpTime < actionDuration)
        {
            t += Time.deltaTime / actionDuration;
            rb.MovePosition(Vector3.Lerp(goFromPosition, goToPosition, t));
            lerpTime += Time.deltaTime;
            if(goToPosition == startPosition && t >= deathColliderActivationPercentage && deathColliderHolder.activeSelf == false)
            {
                deathColliderHolder.SetActive(true);
            }
            yield return new WaitForEndOfFrame();
        }

        SwapLocationValues();
       

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
            deathColliderHolder.SetActive(false);
        }
    }
}
