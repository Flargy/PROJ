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
    private bool coroutineIsRunning = false;
    private bool openDoor = true;
    private Coroutine openAndCloseDoors = null;

    public override void ExecuteAction()
    {
        if(coroutineIsRunning == true)
        {
            StopCoroutine(openAndCloseDoors);
            coroutineIsRunning = false;
            
        }
        fromRotation = transform.localRotation.eulerAngles;
        t = 0.0f;
        lerpTime = 0.0f;
        if (usesPlates == true)
        {
            foreach (PressurePlate pressedPlate in plates)
            {
                if (pressedPlate.GetPushed() == false)
                {
                    openDoor = false;

                    break;
                }
                else if (pressedPlate.GetPushed() == true)
                {

                    openDoor = true;
                }

            }
            ChangeRotationValues();

            if (openDoor == true)
            {
                openAndCloseDoors = StartCoroutine(RotateDoors());
            }
            else 
            {
                openAndCloseDoors = StartCoroutine(RotateDoors());
            }

        }

        if (usesPlates == false)
        {
            if (coroutineIsRunning == false)
            {
                openAndCloseDoors = StartCoroutine(RotateDoors());
            }

        }
        

        

    }

    private void Start()
    {
        originalRotation = transform.localRotation.eulerAngles;
        fromRotation = transform.localRotation.eulerAngles;
        toRotation = endRotation;
    }

    private IEnumerator RotateDoors()
    {
        coroutineIsRunning = true;
        while (lerpTime < actionDuration)
        {
            t += Time.deltaTime / actionDuration;
            transform.localRotation = Quaternion.Euler(Vector3.Lerp(fromRotation, toRotation, t));
            lerpTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if(usesPlates == false)
        {
            ChangeRotationValues();
        }
        coroutineIsRunning = false;
     
    }
    

    private void ChangeRotationValues()
    {
        if (openDoor == true)
        {
            fromRotation = transform.localRotation.eulerAngles;
            toRotation = endRotation;
        }
        else
        {
            toRotation = originalRotation;
            fromRotation = transform.localRotation.eulerAngles;
        }
        
        ;
        t = 0.0f;
        lerpTime = 0.0f;
    }

    
}
