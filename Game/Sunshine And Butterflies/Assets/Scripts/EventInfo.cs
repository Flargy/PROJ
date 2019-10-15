using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Main Author: Marcus Lundqvist
//Secondary Author: Hjalmar Andersson

public abstract class EventInfo 
{

}
//Time Events
public class TestEventInfo : EventInfo
{
}

public class PressButtonEventInfo: EventInfo
{
    public int number;
}


