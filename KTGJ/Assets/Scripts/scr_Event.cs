using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Event
{
    public virtual void RunEvent() { }
    public enum Status
    {
        ACTIVE, ARCHIVED
    }
}

public class emailEvent : scr_Event
{
    private Status status;
    public Status getStatus() { return status; }
    public void setStatus(Status setVal) { status = setVal; }

    private Sprite icon;
    public Sprite getIcon() { return icon; }
    public void setIcon(Sprite setVal) { icon = setVal; }

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

    private bool readUnread;
    public bool getReadUnread() { return readUnread; }
    public void setReadUnread(bool setVal) { readUnread = setVal; }

    private bool acceptDecline;
    public bool getAcceptDecline() { return acceptDecline; }
    public void setAcceptDecline(bool setVal) { acceptDecline = setVal; }

    public emailEvent(Status in_status, float in_timeStamp, bool in_readUnread)
    {
        status = in_status;
        timeStamp = in_timeStamp;
        readUnread = in_readUnread;
        generateEmailData();
    }

    public override void RunEvent()
    {
        // TODO:

        readUnread = false;

        // View email

        // Display info

        // Accept or Decline

        // Set to inactive/archived
    }

    private void generateEmailData()
    {
        // Create a randomly gen email from database

        sender = "";
        subject = "";
        timeRecieved = timeStamp.ToString();
        message = "";
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