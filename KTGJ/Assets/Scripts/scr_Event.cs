using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Event : MonoBehaviour
{
    public virtual void RunEvent(int id) { }
    public enum EmailType
    {
        CHOICE, SPAM, TUTORIAL
    }
    public enum Status
    {
        ACTIVE, ARCHIVED
    }

    private EmailType type;
    public EmailType getType() { return type; }
    public void setType(EmailType setVal) { type = setVal; }

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
    public void setSender(string setVal) { sender = setVal; }

    private string subject;
    public string getSubject() { return subject; }
    public void setSubject(string setVal) { subject = setVal; }

    private string message;
    public string getMessage() { return message; }
    public void setMessage(string setVal) { message = setVal; }

    private string timeRecieved;
    public string getTimeRecieved() { return timeRecieved; }
    public void setTimeRecieved(string setVal) { timeRecieved = setVal; }

    private bool readUnread;
    public bool getReadUnread() { return readUnread; }
    public void setReadUnread(bool setVal) { readUnread = setVal; }

    private bool acceptDecline;
    public bool getAcceptDecline() { return acceptDecline; }
    public void setAcceptDecline(bool setVal) { acceptDecline = setVal; }
}

public class emailEvent : scr_Event
{
    public emailEvent(Status in_status, float in_timeStamp, bool in_readUnread)
    {
        scr_Database.EmailData emailData = scr_Database.database.GenerateEmailData();

        setStatus(in_status);
        setTimeStamp(in_timeStamp);
        setReadUnread(in_readUnread);
        setSender(emailData.getSender());
        setSubject(emailData.getSubject());
        setMessage(emailData.getMessage());
        setTimeRecieved(emailData.getTimeRecieved());
    }

    public override void RunEvent(int id)
    {
        setReadUnread(false);
        GameObject openedEmailObject = Instantiate(scr_EventManager.eventManager.openedEmailPrefab, GameObject.FindGameObjectWithTag("EmailScreenNoMask").gameObject.transform);
        openedEmailObject.GetComponentInChildren<scr_OpenEmail>().setEmailContents(id ,getSender(), getSubject(), getTimeRecieved(), getMessage());
    }
}

public class spamEmailEvent : scr_Event
{
    public spamEmailEvent(Status in_status, float in_timeStamp, bool in_readUnread)
    {
        scr_Database.SpamData spamData = scr_Database.database.GenerateSpamData();

        setStatus(in_status);
        setTimeStamp(in_timeStamp);
        setReadUnread(in_readUnread);
        setSender(spamData.getSender());
        setSubject(spamData.getSubject());
        setMessage(spamData.getMessage());
        setTimeRecieved(spamData.getTimeRecieved());
    }

    public override void RunEvent(int id)
    {
        setReadUnread(false);
        GameObject openedEmailObject = Instantiate(scr_EventManager.eventManager.openedSpamPrefab, GameObject.FindGameObjectWithTag("EmailScreenNoMask").gameObject.transform);
        openedEmailObject.GetComponentInChildren<scr_OpenEmail>().setEmailContents(id, getSender(), getSubject(), getTimeRecieved(), getMessage());
    }
}

public class tutorialInformationEvent : scr_Event
{
    public tutorialInformationEvent(Status in_status, float in_timeStamp, bool in_readUnread)
    {
        scr_Database.TutorialData tutorialData = scr_Database.database.GenerateTutorialData();

        setStatus(in_status);
        setTimeStamp(in_timeStamp);
        setReadUnread(in_readUnread);
        setSender(tutorialData.getSender());
        setSubject(tutorialData.getSubject());
        setMessage(tutorialData.getMessage());
        setTimeRecieved(tutorialData.getTimeRecieved());
    }

    public override void RunEvent(int id)
    {
        setReadUnread(false);
        GameObject openedEmailObject = Instantiate(scr_EventManager.eventManager.openedTutorialPrefab, GameObject.FindGameObjectWithTag("EmailScreenNoMask").gameObject.transform);
        openedEmailObject.GetComponentInChildren<scr_OpenEmail>().setEmailContents(id, getSender(), getSubject(), getTimeRecieved(), getMessage(), 24);
    }
}