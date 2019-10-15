using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private AffectedObject affectedObject;
    private int itemsOnPad;

    private void OnTriggerEnter(Collider other)
    {
        itemsOnPad++;

        affectedObject.ExecuteAction();
    }

    private void OnTriggerExit(Collider other)
    {
        itemsOnPad--;
        affectedObject.ExecuteAction();
    }

    public bool GetPushed()
    {
        if(itemsOnPad > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
