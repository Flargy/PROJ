using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Affected2WayDoor : AffectedObject
{
    [SerializeField] private List<PressurePlate> plates;
    private bool doorIsOpen = false;
    private Vector3 startPosition;

    public override void ExecuteAction()
    {

        foreach (PressurePlate pressedPlate in plates)
        {
            if (pressedPlate.GetPushed() == false)
            {
                doorIsOpen = false;
                break;
            }
            else
            {
                doorIsOpen = true;
            }

        }

        if (doorIsOpen == true)
        {
            transform.position += Vector3.down * 5;
        }
        else
        {
            transform.position = startPosition;
        }


    }

    private void Start()
    {
        startPosition = transform.position;
    }
}
