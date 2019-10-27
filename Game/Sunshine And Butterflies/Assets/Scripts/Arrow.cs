﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public AudioClip fireSound;
    public AudioClip hitSound;

    private AudioSource arrowSound;

    public float arrowVelocity;
    public float arroLife = 2.0f;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * arrowVelocity;

        arrowSound = gameObject.GetComponent<AudioSource>();
        arrowSound.clip = fireSound;
        arrowSound.Play();

    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(timer <= arroLife)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
