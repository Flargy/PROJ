using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject holdingPlayer = null;

    private bool followPlayer = true;

    void Update()
    {
        if(followPlayer == true)
        {
            transform.position = holdingPlayer.transform.position;
        }
        else
        {
            transform.position = new Vector3(holdingPlayer.transform.position.x, transform.position.y, holdingPlayer.transform.position.z);
        }
    }

    public void StopFollowingPlayer()
    {
        followPlayer = false;
    }

    public void StartFollowingPlayer()
    {
        followPlayer = true;
    }
}
