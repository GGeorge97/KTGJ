using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Event : MonoBehaviour
{
    public virtual void RunEvent(int id) { }
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
        scr_Database.EmailData emailData = scr_Database.database.GenerateEmailData();

        status = in_status;
        timeStamp = in_timeStamp;
        readUnread = in_readUnread;
        sender = emailData.getSender();
        subject = emailData.getSubject();
        message = emailData.getMessage();
        timeRecieved = timeStamp.ToString();
    }

    public override void RunEvent(int id)
    {
        // TODO:

        readUnread = false;

        GameObject openedEmailObject = Instantiate(scr_EventManager.eventManager.openedEmailPrefab, GameObject.FindGameObjectWithTag("EmailScreenNoMask").gameObject.transform);
        openedEmailObject.GetComponentInChildren<scr_OpenEmail>().setEmailContents(sender, subject, timeRecieved, message);

        // View email

        // Display info

        // Accept or Decline

        // Set to inactive/archived
    }
}

public class communicateEvent : scr_Event
{
    public override void RunEvent(int id)
    {
        // TODO: Start communication game
    }
}

public class treatmentEvent : scr_Event
{
    public override void RunEvent(int id)
    {
        // TODO: Deal with something
    }
}