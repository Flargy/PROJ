﻿using System.Collections;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("CarryBox"))
        {
            
            itemsOnPad++;
            
            foreach (AffectedObject affected in affectedObject)
            {
                if (itemsOnPad == desiredNrOfObjects)
                {
                    affected.ExecuteAction();
                    colorObject.material = activatedColor;
                    audioSource.PlayOneShot(activatedSound);
                }
            }

            foreach(DoorLightChange light in lights)
            {
                light.ChangeEmission(itemsOnPad / desiredNrOfObjects);
            }
        }
        Debug.Log("On: " + itemsOnPad);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("CarryBox"))
        {
            itemsOnPad--;
            foreach (AffectedObject affected in affectedObject)
            {
                if (itemsOnPad < desiredNrOfObjects)
                {
                    affected.ExecuteAction();
                    colorObject.material = startingColor;
                    audioSource.PlayOneShot(deActivatedSound);
                }
            }

            foreach(DoorLightChange light in lights)
            {
                light.ChangeEmission(itemsOnPad / desiredNrOfObjects);
            }
        }
        Debug.Log("Off: " + itemsOnPad);
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
