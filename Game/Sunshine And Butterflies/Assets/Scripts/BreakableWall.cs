using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    [SerializeField] private float force = 200.0f;
    [SerializeField] private float timeToDestroy = 4.0f;
    private Rigidbody[] rb;
    private bool hasBeenUsed = false;
    void Start()
    {
        rb = GetComponentsInChildren<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CarryBox") && hasBeenUsed == false)
        {
            foreach(Rigidbody rig in rb)
            {
                rig.isKinematic = false;
                rig.useGravity = true;
                rig.AddForce(rig.gameObject.transform.forward * force);
            }
            hasBeenUsed = true;
           
        }
    }

    private IEnumerator DestroyDebris()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
