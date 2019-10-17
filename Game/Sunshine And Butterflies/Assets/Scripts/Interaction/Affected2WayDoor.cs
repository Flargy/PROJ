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
        if (plates[0].GetPushed() == true)
        {
            
            doorIsOpen = true;
            transform.position += Vector3.down * 5;
        }
        else
        {
            doorIsOpen = false;
            transform.position = startPosition;
        }
            
    }

    private void Start()
    {
        startPosition = transform.position;
    }
}
