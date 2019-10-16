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
    private bool carryingABox = false;
    private bool airBorne = false;
    private GameObject carriedBox;
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
        if (carryingABox == false) // placeholder
        {

            if (Physics.Raycast(transform.position, transform.forward, out ray, 2.0f, interactionLayer))
            {
                if (ray.collider.CompareTag("CarryBox"))
                {
                    carriedBox = ray.collider.gameObject;
                    Interactable interactionObject = ray.collider.GetComponent<Interactable>();
                    interactionObject.Interact(gameObject);
                    carryingABox = true;
                    Debug.Log(carryingABox);
                }
                else
                {
                    Interactable interactionObject = ray.collider.GetComponent<Interactable>();
                    interactionObject.DistanceCheck(transform.position);
                }
            }
        }

        else if (carryingABox == true) //Ska brytas ut till egen state
        {

            carriedBox.GetComponent<InteractionPickUp>().Drop();
            carryingABox = false;
        }
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
        if (Physics.Raycast(transform.position, Vector3.down, 0.8f, groundLayer))
        {
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
