using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    [SerializeField] private float force = 200.0f;
    private Rigidbody[] rb;

    void Start()
    {
        rb = GetComponentsInChildren<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CarryBox"))
        {
            foreach(Rigidbody rig in rb)
            {
                rig.isKinematic = false;
                rig.useGravity = true;
                rig.AddForce(rig.gameObject.transform.forward * force);
            }
            Destroy(this);
        }
    }


}
