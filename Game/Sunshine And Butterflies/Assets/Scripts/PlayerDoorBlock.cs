using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoorBlock : MonoBehaviour
{
    [SerializeField] private GameObject otherCollider = null;

    private bool done = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && done == false)
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("Player1"))
            {
                ChangeLayer("AcceptPlayer1");
                otherCollider.GetComponent<PlayerDoorBlock>().ChangeLayer("AcceptPlayer2");
            }
            else if(other.gameObject.layer == LayerMask.NameToLayer("Player2"))
            {
                ChangeLayer("AcceptPlayer2");
                otherCollider.GetComponent<PlayerDoorBlock>().ChangeLayer("AcceptPlayer1");
            }
        }
    }

    public void ChangeLayer(string layerName)
    {
        gameObject.layer = LayerMask.NameToLayer(layerName);
        done = true;
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
    }
}
