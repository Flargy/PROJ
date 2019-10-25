using System.Collections;
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
        box.GetComponent<Interactable>().Teleport();
        box.SetActive(false);
        box.GetComponent<Rigidbody>().velocity = Vector3.zero;
        yield return new WaitForSeconds(transferTime);
        box.transform.position = teleportToLocation.position;
        box.SetActive(true);
    }
}
