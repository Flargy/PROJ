using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButton : Interactable
{
    [SerializeField] private AffectedObject affectedObject = null;
    [SerializeField] private GameObject button = null;
    [SerializeField] private bool onTimer = false;
    [SerializeField] private float durationToClose = 2.0f;

    private Vector3 startPosition = Vector3.zero;
    private float lerpTime = 0;
    private float t = 0;
    private Vector3 pressedPosition = Vector3.zero;
    private Vector3 notPressedPosition = Vector3.zero;

    public override void Interact(GameObject player)
    {
        if (interacting == false)
        {
            affectedObject.ExecuteAction();
            interacting = true;
            StartCoroutine(InteractionCooldown());
            StartCoroutine(ButtonMovement());
            if(onTimer == true)
            {
                StartCoroutine(OnATimer());
            }
        }
    }

    private void Start()
    {
        pressedPosition = button.transform.position - ((button.transform.up * 0.1f));
        notPressedPosition = button.transform.position;
    }

    private IEnumerator InteractionCooldown()
    {
        yield return new WaitForSeconds(interactionCooldownTimer);
        interacting = false;
    }

    private IEnumerator ButtonMovement()
    {
        while (lerpTime < 1)
        {
            t += Time.deltaTime;
            button.transform.position = Vector3.Lerp(notPressedPosition, pressedPosition, t);
            lerpTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        t = 0.0f;
        lerpTime = 0.0f;

        while (lerpTime < 1)
        {
            t += Time.deltaTime;
            button.transform.position = Vector3.Lerp(pressedPosition, notPressedPosition, t);
            lerpTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        t = 0.0f;
        lerpTime = 0.0f;
    }

    private IEnumerator OnATimer()
    {
        yield return new WaitForSeconds(durationToClose);
        affectedObject.ExecuteAction();
    }

    
}
