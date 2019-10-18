using UnityEngine;

public class AffectedMovement : AffectedObject
{
    [SerializeField] private Vector3 startPosition = Vector3.zero;
    [SerializeField] private Transform endPosition = null;



    public override void ExecuteAction()
    {
        if(transform.position == startPosition)
        {
            transform.position = endPosition.position;
        }
        else
        {
            transform.position = startPosition;
        }
    }

    private void Start()
    {
        startPosition = transform.position;
    }

}
