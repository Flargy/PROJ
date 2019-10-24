using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

    public Transform startPoint;
    public Transform endPoint;
    LineRenderer laserLine;

    public GameObject Laser;
    public bool trapEnable = true;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ToggleLaserTrap", 0, 5f);
        laserLine = GetComponent<LineRenderer>();
       laserLine.SetWidth(.2f, .2f);
    }

    // Update is called once per frame
    void Update()
    {
        laserLine.useWorldSpace = true;
        laserLine.SetPosition(0, startPoint.position);
        laserLine.SetPosition(1, endPoint.position);
    }

    private void ToggleLaserTrap()
    {
        trapEnable = !trapEnable;
        Laser.SetActive(trapEnable);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Dead");
        }
    }
}
