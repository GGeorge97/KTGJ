using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Event
{
    public virtual void runEvent() { }
    public enum Status
    {
        ACTIVE, INACTIVE, ARCHIVED
    }
}

public class emailEvent : scr_Event
{
    private Status status;
    Status getStatus() { return status; }
    void setStatus(Status setVal) { status = setVal; }

    private float timeStamp;
    float getTimeStamp() { return timeStamp; }
    void setTimeStamp(float setVal) { timeStamp = setVal; }

    private GameObject emailObject;
    GameObject getEmail() { return emailObject; }

    public emailEvent(Status in_status, float in_timeStamp)
    {
        status = in_status;
        timeStamp = in_timeStamp;
        //emailObject = GameObject.Instantiate();

    }

    public override void runEvent()
    {
        // View email

    }
}

public class communicateEvent : scr_Event
{
    public override void runEvent()
    {
        // Start communication game
    }
}

public class treatmentEvent : scr_Event
{
    public override void runEvent()
    {
        // Deal with something
    }
}