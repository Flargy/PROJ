using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerQTE : MonoBehaviour
{
    private InteractionLever currentLever = null;
    private PlayerInput playerInput = null;
    private Vector3 moveToPosition = Vector3.zero;
    private Vector3 moveFromPosition = Vector3.zero;
    private float t = 0;
    private float lerpTime = 0;
    private Rigidbody rb = null;
    private Vector3 targetRotation = Vector3.zero;
    private Quaternion fromRotation = Quaternion.identity;
    private Quaternion toRotation = Quaternion.identity;


    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }

    public void SwapToQTE(InteractionLever lever, GameObject leverPosition)
    {
        currentLever = lever;
        playerInput.SwitchCurrentActionMap("QTE");


        Vector3 placement = new Vector3(leverPosition.transform.position.x, transform.position.y, leverPosition.transform.position.z);
        moveToPosition = placement + leverPosition.transform.forward * 0.4f + -leverPosition.transform.right * 0.5f;
        targetRotation = (placement + leverPosition.transform.forward * 0.4f) - moveToPosition;
        fromRotation = transform.rotation;
        moveFromPosition = rb.transform.position;
        toRotation = Quaternion.LookRotation(targetRotation, Vector3.up);
        StartCoroutine(PlaceAndRotate());
    }

    public void SwapToMovement()
    {
        playerInput.SwitchCurrentActionMap("Gameplay");
    }

    public void OnDown()
    {
        currentLever.ReceiveAnswer(0);
    }

    public void OnLeft()
    {
        currentLever.ReceiveAnswer(1);
    }

    public void OnUp()
    {
        currentLever.ReceiveAnswer(2);
    }

    public void OnRight()
    {
        currentLever.ReceiveAnswer(3);
    }


    private IEnumerator PlaceAndRotate()
    {
        while (lerpTime < 0.7f)
        {
            t += Time.deltaTime / 0.7f;
            rb.MovePosition(Vector3.Lerp(moveFromPosition, moveToPosition, t));
            rb.MoveRotation(Quaternion.Lerp(fromRotation, toRotation, t));
            lerpTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        t = 0;
        lerpTime = 0;
    }
}
