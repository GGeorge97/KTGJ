using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Event
{
    public virtual void RunEvent() { }
    public enum Status
    {
        ACTIVE, INACTIVE, ARCHIVED
    }
}

public class emailEvent : scr_Event
{
    private Status status;
    public Status getStatus() { return status; }
    public void setStatus(Status setVal) { status = setVal; }

    private float timeStamp;
    public float getTimeStamp() { return timeStamp; }
    public void setTimeStamp(float setVal) { timeStamp = setVal; }

    private string sender;
    public string getSender() { return sender; }

    private string subject;
    public string getSubject() { return subject; }

    private string message;
    public string getMessage() { return message; }

    private string timeRecieved;
    public string getTimeRecieved() { return timeRecieved; }

    private bool acceptDecline;
    public bool getAcceptDecline() { return acceptDecline; }
    public void setAcceptDecline(bool setVal) { acceptDecline = setVal; }

    public emailEvent(Status in_status, float in_timeStamp)
    {
        status = in_status;
        timeStamp = in_timeStamp;
        generateEmailData();
    }

    public override void RunEvent()
    {
        // TODO:

        // View email

        // Display info

        // Accept or Decline

        // Set to inactive/archived
    }

    private void generateEmailData()
    {
        // Create a randomly gen email from database

        sender = "WhitehouseUrgent@USA.gov";
        subject = "Your Mission";
        timeRecieved = timeStamp.ToString();
        message = "Good day, Sir. /n You must look after this alien blah blah blah.";
    }
}

public class communicateEvent : scr_Event
{
    public override void RunEvent()
    {
        // TODO: Start communication game
    }
}

public class treatmentEvent : scr_Event
{
    public override void RunEvent()
    {
        // TODO: Deal with something
    }
}