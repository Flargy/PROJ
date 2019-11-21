using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButton : Interactable
{
    [SerializeField] private AffectedObject affectedObject = null;
    [SerializeField] private GameObject button = null;
    [SerializeField] private bool onTimer = false;
    [SerializeField] private float durationToClose = 2.0f;
    [SerializeField] private List<Interactable> connectedSwitches = null;

    private float lerpTime = 0;
    private float t = 0;
    private Vector3 pressedPosition = Vector3.zero;
    private Vector3 notPressedPosition = Vector3.zero;
    private AudioSource audioSource;
    public AudioClip buttonSoundIn;
    public AudioClip buttonSoundOut;

    public override void Interact(GameObject player)
    {
        if (interacting == false)
        {
            affectedObject.ExecuteAction();
            interacting = true;
            StartCoroutine(InteractionCooldown());
            if(button != null)
            { 
                StartCoroutine(ButtonMovement());
            }
            if(onTimer == true)
            {
                StartCoroutine(OnATimer());
            }
            foreach (Interactable otherSwitch in connectedSwitches)
            {
                if (otherSwitch.interacting == false)
                {
                    otherSwitch.StartInteraction();
                }
            }
        }
    }

    private void Start()
    {

        audioSource = GetComponent<AudioSource>();
        if(button != null)
        { 
            pressedPosition = button.transform.position - ((button.transform.up * 0.1f));
        notPressedPosition = button.transform.position;
        }
    }

    //private IEnumerator InteractionCooldown()
    //{
    //    yield return new WaitForSeconds(interactionCooldownTimer);
    //    interacting = false;
    //}

    private IEnumerator ButtonMovement()
    {
        while (lerpTime < 1)
        {
            t += Time.deltaTime;
            button.transform.position = Vector3.Lerp(notPressedPosition, pressedPosition, t);
            lerpTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        audioSource.PlayOneShot(buttonSoundIn);
        Debug.Log("Ljud 1");
        t = 0.0f;
        lerpTime = 0.0f;

        while (lerpTime < 1)
        {
            t += Time.deltaTime;
            button.transform.position = Vector3.Lerp(pressedPosition, notPressedPosition, t);
            lerpTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        audioSource.PlayOneShot(buttonSoundOut);
        Debug.Log("Ljud 2");
        t = 0.0f;
        lerpTime = 0.0f;
    }

    private IEnumerator OnATimer()
    {
        yield return new WaitForSeconds(durationToClose);
        affectedObject.ExecuteAction();
    }

    
}
