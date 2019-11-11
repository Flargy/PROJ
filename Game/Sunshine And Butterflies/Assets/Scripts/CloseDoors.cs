using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoors : MonoBehaviour
{
    [SerializeField] private GameObject[] doorsToClose;
    [SerializeField] private GameObject[] doorsToOpen;
    [SerializeField] private Vector3 closedRotation = Vector3.zero;
    [SerializeField] private Vector3 openRotation = Vector3.zero;

    private float t = 0.0f;
    private int playerCount = 0;
    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        
        playerCount++;
        if(playerCount == 2 && activated == false)
        {
            activated = true;
            StartCoroutine(OpenAndCloseDoors());
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
       
          playerCount--;
        
    }

    private IEnumerator OpenAndCloseDoors()
    {
        
        while(t < 1.0f)
        {
            t += Time.deltaTime;
            foreach(GameObject door in doorsToClose)
            {
                door.transform.rotation = Quaternion.Euler(Vector3.Lerp(openRotation, closedRotation, t));
            }

            foreach(GameObject door in doorsToOpen)
            {
                door.transform.rotation = Quaternion.Euler(Vector3.Lerp(closedRotation, openRotation, t));
            }
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
