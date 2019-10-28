using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectedDoor : AffectedObject
{
    [SerializeField] private List<PressurePlate> plates = null;
    [SerializeField] private bool usesPlates = false;
    [SerializeField] private Vector3 endRotation = Vector3.zero;

    private float lerpTime = 0;
    private float t = 0;
    private Vector3 fromRotation = Vector3.zero;
    private Vector3 originalRotation = Vector3.zero;
    private Vector3 toRotation = Vector3.zero;
    private bool doorIsOpen = false;
    private Vector3 startPosition;

    public override void ExecuteAction()
    {
        if (doorIsOpen == false && usesPlates == true)
        {
            foreach (PressurePlate pressedPlate in plates)
            {
                if (pressedPlate.GetPushed() == false)
                {
                    doorIsOpen = false;
                    
                    break;
                }
                else if (pressedPlate.GetPushed() == true)
                {
                    
                    doorIsOpen = true;
                }

            }

            if (doorIsOpen == true)
            {
                transform.position += Vector3.down * 5;
            }
            
        }
        else if(usesPlates == true)
        {
            transform.position = startPosition;
            doorIsOpen = false;
        }

        if(usesPlates == false)
        {
            doorIsOpen = !doorIsOpen;
            if (doorIsOpen == true)
            {
                StartCoroutine(ChangePosition());
            }
            else
            {
                StartCoroutine(ChangePosition());
            }
        }


    }

    private void Start()
    {
        startPosition = transform.position;
        originalRotation = transform.rotation.eulerAngles;
        fromRotation = transform.rotation.eulerAngles;
        toRotation = endRotation;
    }

    private IEnumerator ChangePosition()
    {
        Debug.Log("rotating");
        while (lerpTime < actionDuration)
        {
            t += Time.deltaTime / actionDuration;
            transform.rotation = Quaternion.Euler(Vector3.Lerp(fromRotation, toRotation, t));
            lerpTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        if (fromRotation == originalRotation)
        {
            fromRotation = transform.rotation.eulerAngles;
            toRotation = originalRotation;
        }
        else
        {
            toRotation = endRotation;
            fromRotation = transform.rotation.eulerAngles;
        }
        t = 0.0f;
        lerpTime = 0.0f;
    }
}
