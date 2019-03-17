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

class emailEvent : scr_Event
{
    private string sender;
    private string subject;
    private string message;


    private bool acceptDecline;
    private Status status;

    public emailEvent(string in_sender, string in_subject, string in_message)
    {
        sender = in_sender;
        subject = in_subject;
        message = in_message;
    }

    public override void runEvent()
    {
        // View email
    }
}

class communicateEvent : scr_Event
{
    public override void runEvent()
    {
        // Start communication game
    }
}

class treatmentEvent : scr_Event
{
    public override void runEvent()
    {
        // Deal with something
    }
}