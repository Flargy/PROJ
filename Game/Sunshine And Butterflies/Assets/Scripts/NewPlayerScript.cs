using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerScript : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask interactionLayer;
    [SerializeField] private float moveSpeed = 6.0f;
    [SerializeField] private float jumpPower = 5.0f;

    private Rigidbody rb = null;
    private Vector2 movementVector = Vector2.zero;
    private bool interacting = false;
    private bool CarryingAObject = false;
    private bool airBorne = false;
    private GameObject carriedObject;
    private float jumpGroundCheckDelay = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(airBorne == false && interacting == false)
        {
            ApplyGroundVelocity();
            TurnToFace();
        }
        else if(airBorne == true)
        {
            jumpGroundCheckDelay += Time.deltaTime;
            ApplyAirVelocity();
            if(GroundCheck() == true && jumpGroundCheckDelay >= 0.3f)
            {
                airBorne = false;
                jumpGroundCheckDelay = 0.0f;
            }
        }
    }

    public void TurnToFace()
    {
        Vector3 movementVector = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (movementVector != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movementVector);
        }
    }

    public void OnInteract()
    {
        RaycastHit ray;
        if (CarryingAObject == false) // placeholder
        {

            if (Physics.Raycast(transform.position, transform.forward, out ray, 2.0f, interactionLayer))
            {
                
                Interactable interactionObject = ray.collider.GetComponent<Interactable>();
                interactionObject.DistanceCheck(gameObject);
                CarryingAObject = true;
                
               
            }
        }

        else if (CarryingAObject == true && carriedObject != null) //Ska brytas ut till egen state
        {

            carriedObject.GetComponent<Interactable>().Interact(gameObject);
        }
    }

    public void PickUpObject(GameObject carried)
    {
        carriedObject = carried;
        CarryingAObject = true;
    }

    public void DropObject()
    {
        carriedObject = null;
        CarryingAObject = false;
    }

    public void ApplyGroundVelocity()
    {
        rb.velocity = (new Vector3(movementVector.x, 0, movementVector.y) * moveSpeed) + new Vector3(0, rb.velocity.y, 0);
        if (new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude >= 2.51f)
        {
            float yVelocity = rb.velocity.y;
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, 2.5f);
            rb.velocity = new Vector3(rb.velocity.x, yVelocity, rb.velocity.z);
        }
    }

    public bool GroundCheck()
    {
        BoxCollider box = GetComponent<BoxCollider>();
        if (Physics.BoxCast(transform.position + Vector3.up, new Vector3(0.5f, 0.75f, 0.5f), Vector3.down, transform.rotation, 1.5f, groundLayer))
        {
            Debug.Log(true);
            return true;
        }
        return false;
    }

    public void ApplyAirVelocity()
    {
        Vector2 currentVelocity = new Vector2(rb.velocity.x, rb.velocity.z);
        float turndot = Vector2.Dot(currentVelocity, movementVector);
        if (turndot < 0.3)
        {
            rb.velocity += (new Vector3(movementVector.x, 0, movementVector.y) * 0.05f);

        }

    }

    public void OnMove(InputValue value)
    {
        movementVector = value.Get<Vector2>();
    }

    public void OnJump()
    {
        if (GroundCheck() == true && interacting == false)
        {
            rb.velocity += Vector3.up * jumpPower;
            airBorne = true;
        }
    }
}
