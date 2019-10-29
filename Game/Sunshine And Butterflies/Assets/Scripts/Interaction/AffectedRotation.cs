using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectedRotation : AffectedObject
{
    [SerializeField] private Vector3 endRotation = Vector3.zero;

    private float lerpTime = 0;
    private float t = 0;
    private Vector3 fromRotation = Vector3.zero;
    private Vector3 originalRotation = Vector3.zero;
    private Vector3 toRotation = Vector3.zero;
    

    public override void ExecuteAction()
    {

        StartCoroutine(ChangeRotation());
    }

    private void Start()
    {
        originalRotation = transform.rotation.eulerAngles;
        fromRotation = transform.rotation.eulerAngles;
        toRotation = endRotation;
    }

    private IEnumerator ChangeRotation()
    {
        while (lerpTime < actionDuration)
        {
            t += Time.deltaTime / actionDuration;
            transform.rotation = Quaternion.Euler(Vector3.Lerp(fromRotation, toRotation, t));
            lerpTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        if (fromRotation == originalRotation)
        {
            fromRotation = transform.rotation.eulerAngles;
            toRotation = originalRotation;
        }
        else
        {
            toRotation = endRotation;
            fromRotation = transform.rotation.eulerAngles;
        }
        t = 0.0f;
        lerpTime = 0.0f;
    }
}
