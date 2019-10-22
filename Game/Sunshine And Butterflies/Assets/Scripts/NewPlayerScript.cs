using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerScript : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer = 1;
    [SerializeField] private LayerMask interactionLayer = 1;
    [SerializeField] private float moveSpeed = 6.0f;
    [SerializeField] private float jumpPower = 5.0f;

    private Rigidbody rb = null;
    private Vector2 movementVector = Vector2.zero;
    private bool interacting = false;
    private bool CarryingAObject = false;
    private bool airBorne = false;
    private GameObject carriedObject;
    private float jumpGroundCheckDelay = 0.0f;
    private bool isLifted = false;
    private bool canBeLifted = true;
    private Interactable interactScript = null;
    private CapsuleCollider capsule = null;
    private Vector3 capsuleTop = Vector3.zero;
    private Vector3 capsuleBottom = Vector3.zero;

    void Start()
    {
        capsule = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        interactScript = GetComponent<Interactable>();
    }

    void Update()
    {
        
        if (airBorne == false && interacting == false && isLifted == false)
        {
            ApplyGroundVelocity();
            TurnToFace();
        }
        else if (airBorne == true && isLifted == false)
        {
            jumpGroundCheckDelay += Time.deltaTime;
            ApplyAirVelocity();
            TurnToFace();
            if (GroundCheck() == true && jumpGroundCheckDelay >= 0.3f)
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
        if (isLifted == false)
        {
            RaycastHit ray;
            if (CarryingAObject == false) // placeholder
            {
                capsuleTop = transform.position + (capsule.center + Vector3.up * (capsule.height / 2 - capsule.radius));
                capsuleBottom = transform.position + (capsule.center + Vector3.down * (capsule.height / 2 - capsule.radius));
                if (Physics.CapsuleCast(capsuleTop, capsuleBottom, capsule.radius, transform.forward, out ray, 2, interactionLayer))
                {

                    Interactable interactionObject = ray.collider.GetComponent<Interactable>();
                    interactionObject.DistanceCheck(gameObject);


                }
            }

            else if (CarryingAObject == true && carriedObject != null) 
            {
                carriedObject.GetComponent<Interactable>().Interact(gameObject);
            }
        }

    }

    public void PickUpObject(GameObject carried)
    {
        canBeLifted = false;
        carriedObject = carried;
        CarryingAObject = true;
    }

    public void DropObject()
    {
        canBeLifted = true;
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
        capsuleTop = transform.position + capsule.center + Vector3.up * (capsule.height / 2.1f - capsule.radius);
        capsuleBottom = transform.position + capsule.center + Vector3.down * (capsule.height / 2.1f - capsule.radius);
        if (Physics.CapsuleCast(capsuleTop, capsuleBottom, capsule.radius, Vector3.down, 0.15f, groundLayer))
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
        if (isLifted == false)
        {
            movementVector = value.Get<Vector2>();
        }
    }

    public void OnJump()
    {
        if (GroundCheck() == true && interacting == false && isLifted == false && CarryingAObject == false)
        {
            rb.velocity += Vector3.up * jumpPower;
            airBorne = true;
        }
    }

    public void OnToss()
    {
        if(CarryingAObject == true)
        {
            carriedObject.GetComponent<Interactable>().Toss();
        }
    }

    //Player to player interactions

    public bool CanBeLifted()
    {
        return canBeLifted;
    }

    public void SwapLiftingState()
    {
        canBeLifted = !canBeLifted;
    }

    public void BecomeLifted()
    {
        //GetComponent<PlayerInput>().currentActionMap = QTE;
        
        isLifted = true;
    }

    public void Released()
    {
        isLifted = false;
        airBorne = true;
    }

    public void BreakFree()
    {

    }

    
}
