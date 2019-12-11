using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButton : Interactable
{
    [SerializeField] private AffectedObject affectedObject = null;
    [SerializeField] private AffectedObject[] affectedObjectList = null;
    [SerializeField] private GameObject button = null;
    [SerializeField] private bool onTimer = false;
    [SerializeField] private float durationToClose = 2.0f;
    [SerializeField] private List<Interactable> connectedSwitches = null;
    [SerializeField] private float animationDuration = 0.5f;
    [SerializeField] private float actionDelay = 0.0f;

    private float lerpTime = 0;
    private float t = 0;
    private Vector3 pressedPosition = Vector3.zero;
    private Vector3 notPressedPosition = Vector3.zero;
    private AudioSource audioSource;
    public AudioClip buttonSoundIn;
    public AudioClip buttonSoundOut;

    public override void Interact(GameObject player)
    {
        if (interacting == false && actionDelay <= 0)
        {
            if(affectedObjectList.Length == 0)
            {
                affectedObject.ExecuteAction();
            }
            else
            {
                foreach(AffectedObject obj in affectedObjectList)
                {
                    obj.ExecuteAction();
                }
            }
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
            player.GetComponent<NewPlayerScript>().Freeze(animationDuration);
            player.GetComponent<NewPlayerScript>().StartAnimation("Push Button");
        }
        else if(interacting == false && actionDelay < 0)
        {
            player.GetComponent<NewPlayerScript>().Freeze(animationDuration);
            player.GetComponent<NewPlayerScript>().StartAnimation("Push Button");
            StartCoroutine(ActionDelay());
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

    private IEnumerator ButtonMovement()
    {
        audioSource.PlayOneShot(buttonSoundIn);

        while (lerpTime < 1)
        {
            t += Time.deltaTime;
            button.transform.position = Vector3.Lerp(notPressedPosition, pressedPosition, t);
            lerpTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
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

    private IEnumerator ActionDelay()
    {
        yield return new WaitForSeconds(actionDelay);

        if (interacting == false)
        {
            if (affectedObjectList.Length == 0)
            {
                affectedObject.ExecuteAction();
            }
            else
            {
                foreach (AffectedObject obj in affectedObjectList)
                {
                    obj.ExecuteAction();
                }
            }
            interacting = true;
            StartCoroutine(InteractionCooldown());
            if (button != null)
            {
                StartCoroutine(ButtonMovement());
            }
            if (onTimer == true)
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
    
}
