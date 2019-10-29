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
    private bool coroutineIsRunning = false;
    private bool openDoor = true;
    private Vector3 startPosition;
    private Coroutine openAndCloseDoors = null;

    public override void ExecuteAction()
    {      

        if (coroutineIsRunning == false)
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

                if (doorIsOpen == true && coroutineIsRunning == false)
                {
                    openAndCloseDoors = StartCoroutine(RotateDoors());
                }

            }
            else if (usesPlates == true && coroutineIsRunning == false)
            {
                openAndCloseDoors = StartCoroutine(RotateDoors());
                doorIsOpen = false;
            }

            if (usesPlates == false)
            {
                
                if (coroutineIsRunning == false)
                {
                    openAndCloseDoors = StartCoroutine(RotateDoors());
                }

            }
        }

        else if(coroutineIsRunning == true)
        {
            AbortCoroutine();
        }

    }

    private void Start()
    {
        startPosition = transform.position;
        originalRotation = transform.rotation.eulerAngles;
        fromRotation = transform.rotation.eulerAngles;
        toRotation = endRotation;
    }

    private IEnumerator RotateDoors()
    {
        coroutineIsRunning = true;
        while (lerpTime < actionDuration)
        {
            t += Time.deltaTime / actionDuration;
            transform.rotation = Quaternion.Euler(Vector3.Lerp(fromRotation, toRotation, t));
            lerpTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        ChangeRotationValues();
        
    }

    private void AbortCoroutine()
    {
        ChangeRotationValues();
        openAndCloseDoors = StartCoroutine(RotateDoors());
        StopCoroutine(openAndCloseDoors);
    }

    private void ChangeRotationValues()
    {
        if (openDoor == true)
        {
            fromRotation = transform.rotation.eulerAngles;
            toRotation = originalRotation;
        }
        else
        {
            toRotation = endRotation;
            fromRotation = transform.rotation.eulerAngles;
        }
        openDoor = !openDoor;
        coroutineIsRunning = false;
        t = 0.0f;
        lerpTime = 0.0f;
    }
}
