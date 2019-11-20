using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public AudioClip fireSound;
    public AudioClip hitSound;

    private AudioSource arrowSound = null;

    [SerializeField] private float arrowVelocity;
    [SerializeField] private float arroLife = 2.0f;
    private float timer = 0;
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
