using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(Go());
    }

    IEnumerator Go()
    {
        while (true)
        {
            gameObject.GetComponent<Animation>().Play();
            yield return new WaitForSeconds(3f);
        }
    }
    
}
