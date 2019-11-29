using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private List<AffectedObject> affectedObject = null;
    [SerializeField] private int desiredNrOfObjects = 1;
    [SerializeField] private Material activatedColor = null;
    [SerializeField] private MeshRenderer colorObject = null;
    [SerializeField] private DoorLightChange[] lights = null;
    private float itemsOnPad;
    private bool crouchedOn = false;
    private Material startingColor = null;
    private AudioSource audioSource;
    private GameObject playerOnPad = null;
    public AudioClip activatedSound;
    public AudioClip deActivatedSound;

    private void Start()
    {
        startingColor = colorObject.material;
        audioSource = GetComponent<AudioSource>();

    }

    

    public void LowerCounter()
    {
        itemsOnPad--;
        if(itemsOnPad < desiredNrOfObjects)
        {
            colorObject.material = startingColor;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Player") || other.CompareTag("CarryBox"))
        {
            itemsOnPad++;
            if (itemsOnPad == desiredNrOfObjects)
            {
               
                colorObject.material = activatedColor;
                audioSource.PlayOneShot(activatedSound);
                foreach (AffectedObject affected in affectedObject)
                {
                
                    affected.ExecuteAction();
                    
                }
            }

            foreach(DoorLightChange light in lights)
            {
                light.ChangeEmission(Mathf.Min(itemsOnPad / desiredNrOfObjects, 1.0f));
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("CarryBox"))
        {
            itemsOnPad--;
            if (itemsOnPad < desiredNrOfObjects)
            {
                colorObject.material = startingColor;
                audioSource.PlayOneShot(deActivatedSound);
                foreach (AffectedObject affected in affectedObject)
                {
                
                    affected.ExecuteAction();
                    
                }
            }

            foreach(DoorLightChange light in lights)
            {
                light.ChangeEmission(Mathf.Min(itemsOnPad / desiredNrOfObjects, 1.0f));
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
