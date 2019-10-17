using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private List<AffectedObject> affectedObject;
    [SerializeField] private int desiredNrOfObjects = 1;
    private int itemsOnPad;

    private void OnTriggerEnter(Collider other)
    {
        itemsOnPad++;

        foreach(AffectedObject affected in affectedObject)
        {
            affected.ExecuteAction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        itemsOnPad--;
        foreach (AffectedObject affected in affectedObject)
        {
            affected.ExecuteAction();
        }
    }

    public bool GetPushed()
    {
        if(itemsOnPad >= desiredNrOfObjects)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
