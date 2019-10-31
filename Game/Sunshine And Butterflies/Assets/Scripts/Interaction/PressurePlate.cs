using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private List<AffectedObject> affectedObject = null;
    [SerializeField] private int desiredNrOfObjects = 1;
    [SerializeField] private Material activatedColor = null;
    [SerializeField] private MeshRenderer colorObject = null;
    private int itemsOnPad;
    private Material startingColor = null;

    private void Start()
    {
        startingColor = colorObject.material;
    }

    private void OnTriggerEnter(Collider other)
    {
        itemsOnPad++;

        foreach(AffectedObject affected in affectedObject)
        {
            if(itemsOnPad == desiredNrOfObjects)
            {
                affected.ExecuteAction();
                colorObject.material = activatedColor;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        itemsOnPad--;
        foreach (AffectedObject affected in affectedObject)
        {
            if(itemsOnPad < desiredNrOfObjects)
            {
                affected.ExecuteAction();
                colorObject.material = startingColor;
            }
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
