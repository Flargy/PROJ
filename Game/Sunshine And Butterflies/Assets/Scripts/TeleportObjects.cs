﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObjects : MonoBehaviour
{
    [SerializeField] private Transform teleportToLocation = null;
    [SerializeField] private float transferTime = 2.0f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CarryBox"))
        {
            StartCoroutine(MoveBox(other.gameObject));
        }
    }

    private IEnumerator MoveBox(GameObject box)
    {
        box.SetActive(false);
        yield return new WaitForSeconds(transferTime);
        box.transform.position = teleportToLocation.position;
        box.SetActive(true);
    }
}
