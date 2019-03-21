using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Email
{
    private string sender;
    string getSender() { return sender; }

    private string subject;
    string geSubject() { return subject; }

    private string message;
    string getMessage() { return message; }

    private string timeRecieved;
    string getTimeRecieved() { return timeRecieved; }

    private bool acceptDecline;
    bool getAcceptDecline() { return acceptDecline; }
    void setAcceptDecline(bool setVal) { acceptDecline = setVal; }

    public scr_Email(string in_sender, string in_subject, string in_message)
    {
        sender = in_sender;
        subject = in_subject;
        message = in_message;
    }
    //"WhitehouseUrgent@USA.gov", "Your Mission", "Good day, Sir. /n You must look after this alien blah blah blah."
}
