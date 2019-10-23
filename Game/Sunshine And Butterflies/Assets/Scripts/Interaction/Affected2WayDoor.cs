using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Affected2WayDoor : AffectedObject
{
    [SerializeField] private List<PressurePlate> plates = null;
    [SerializeField] private bool usesPlates = false;
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
                transform.position += Vector3.down * 5;
            }
            else
            {
                transform.position = startPosition;
            }
        }


    }

    private void Start()
    {
        startPosition = transform.position;
    }
}
