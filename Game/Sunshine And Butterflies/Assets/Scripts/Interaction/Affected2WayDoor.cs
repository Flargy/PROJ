using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Affected2WayDoor : AffectedObject
{
    [SerializeField] private List<PressurePlate> plates;

    public override void ExecuteAction()
    {
        if (plates[0].GetPushed() == true && plates[1].GetPushed() == true)
        {
            Debug.Log("open");
        }
        else
            Debug.Log("close");
    }
}
