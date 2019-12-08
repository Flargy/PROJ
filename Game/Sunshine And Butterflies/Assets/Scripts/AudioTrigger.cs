using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{

    private AudioSource audioSource;
    [SerializeField] private AudioClip triggerSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(triggerSound);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        audioSource.Stop();
    }

}
