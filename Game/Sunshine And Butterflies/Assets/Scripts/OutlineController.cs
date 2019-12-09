using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineController : MonoBehaviour
{
    private Outline line = null;

    void Start()
    {
        line = GetComponent<Outline>();
        EventHandeler.Current.RegisterListener(EventHandeler.EVENT_TYPE.SwapOutlineEvent, ChangeOutline);
    }

    private void ChangeOutline(EventInfo info)
    {
        Debug.Log("i was activated");
        line.enabled = !line.enabled;
    }
}
