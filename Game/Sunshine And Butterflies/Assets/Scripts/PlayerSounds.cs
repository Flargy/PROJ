﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip[] footStepsSounds;
    public AudioClip[] jumpingSounds;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayFootStepSound()
    {
        int n = Random.Range(1, footStepsSounds.Length);
        audioSource.clip = footStepsSounds[n];
        audioSource.PlayOneShot(audioSource.clip);
        footStepsSounds[n] = footStepsSounds[0];
        footStepsSounds[0] = audioSource.clip;

    }

    public void PlayJumpSounds()
    {
        int n = Random.Range(1, jumpingSounds.Length);
        audioSource.clip = jumpingSounds[n];
        audioSource.PlayOneShot(audioSource.clip);
        jumpingSounds[n] = jumpingSounds[0];
        jumpingSounds[0] = audioSource.clip;
    }
}
