using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffAndOnLights : MonoBehaviour
{
    [SerializeField] private List<Light> oldLights;
    [SerializeField] private List<Light> newLights;
    [SerializeField] private float litStrength = 0.5f;
    private float lightStrength = 0.0f;
    private float t = 0.0f;
    private int playerCount = 0;
    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCount++;
            if (playerCount == 2)
            {
                activated = true;
                StartCoroutine(ChangeLights());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //playerCount--;
    }

    private IEnumerator ChangeLights()
    {
        lightStrength = oldLights[1].intensity;
        while(t < 1.0f)
        {
            foreach(Light light in oldLights)
            {
                light.intensity = Mathf.Lerp(lightStrength, 0, t);
                yield return new WaitForEndOfFrame();
                if(light.intensity < 0.1f)
                {
                    light.gameObject.SetActive(false);
                }
            }
            t += Time.deltaTime;
        }

        t = 0.0f;
        foreach (Light light in newLights)
        {
           
            light.gameObject.SetActive(true);
            
        }
        while (t < 1.0f)
        {
            foreach(Light light in newLights)
            {
                light.intensity = Mathf.Lerp(0, litStrength, t);
                yield return new WaitForEndOfFrame();
            }
            t += Time.deltaTime;
        }
        t = 0.0f;
        Destroy(gameObject);
    }
}
