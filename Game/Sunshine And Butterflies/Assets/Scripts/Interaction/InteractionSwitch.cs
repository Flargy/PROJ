using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSwitch : Interactable
{
    [SerializeField] private List<AffectedObject> affectedObjects = null;
    [SerializeField] private GameObject button1 = null;
    [SerializeField] private GameObject button2 = null;

    private float lerpTime = 0;
    private float t = 0;
    private Vector3 button1To = Vector3.zero;
    private Vector3 button1From = Vector3.zero;
    private Vector3 button2From = Vector3.zero;
    private Vector3 button2To = Vector3.zero;

    public override void Interact(GameObject player)
    {
        if (interacting == false)
        {
            StartCoroutine(InteractionCooldown());
            StartCoroutine(ButtonMovement());
            foreach (AffectedObject affected in affectedObjects)
            {

                affected.ExecuteAction();

            }
        }
    }

    public override IEnumerator InteractionCooldown()
    {
        interacting = true;
        yield return new WaitForSeconds(interactionCooldownTimer);
        interacting = false;
    }

    private void Start()
    {
        button1To = button1.transform.position - ((button1.transform.forward * 0.1f));
        button1From = button1.transform.position;
        button2To = button2.transform.position - ((button2.transform.forward * -0.1f));
        button2From = button2.transform.position;
    }

    private IEnumerator ButtonMovement()
    {
        while (lerpTime < 1)
        {
            t += Time.deltaTime;
            button1.transform.position = Vector3.Lerp(button1From, button1To, t);
            button2.transform.position = Vector3.Lerp(button2From, button2To, t);
            lerpTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        t = 0.0f;
        lerpTime = 0.0f;

        SwapValues(button1From, button1To, button2From, button2To);
    }

    private void SwapValues(Vector3 b1f, Vector3 b1t, Vector3 b2f, Vector3 b2t)
    {
        button1From = b1t;
        button1To = b1f;
        button2From = b2t;
        button2To = b2f;
    }

}
