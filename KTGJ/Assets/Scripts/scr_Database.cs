using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_Database : MonoBehaviour
{
    // Static reference
    public static scr_Database database;

    public struct EmailData
    {
        private string sender;
        public string getSender() { return sender; }
        public void setSender(string i) { sender = i; }
        private string subject;
        public string getSubject() { return subject; }
        public void setSubject(string i) { subject = i; }
        private string message;
        public string getMessage() { return message; }
        public void setMessage(string i) { message = i; }
    }

    private const int eDataSize = 5;
    private string[] emailSenders;
    private string[] emailSubjects;
    private string[] emailGreetings;
    private string[] emailBody;
    private string[] emailGoodbye;

    public EmailData GenerateEmailData()
    {
        EmailData emailData = new EmailData();

        Random.InitState(System.Environment.TickCount);

        int rand = Random.Range(0, eDataSize);
        emailData.setSender(emailSenders[rand]);

        rand = Random.Range(0, eDataSize);
        emailData.setSubject(emailSubjects[rand]);

        string msg = "";
        rand = Random.Range(0, eDataSize);
        msg += emailGreetings[rand];
        rand = Random.Range(0, eDataSize);
        msg += emailBody[rand];
        rand = Random.Range(0, eDataSize);
        msg += emailGoodbye[rand];
        emailData.setMessage(msg);

        return emailData;
    }

    public struct PhraseData
    {
        private Sprite[] emojis;
        public Sprite[] getEmojis() { return emojis; }
        public void setEmojis(Sprite image, int i) { emojis[i] = image; }
        private string phrase;
        public string getPhrase() { return phrase; }
        public void setPhrase(string i) { phrase = i; }
    }

    private const int pDataSize = 3;
    private Sprite[,] emojiSets;
    private string[] phrases;
    [SerializeField]
    private Sprite emptyEmoji;
    [SerializeField]
    private Sprite emoji1;
    [SerializeField]
    private Sprite emoji2;
    [SerializeField]
    private Sprite emoji3;

    public PhraseData RetrievePhrase()
    {
        PhraseData phraseData = new PhraseData();

        Random.InitState(System.Environment.TickCount);

        int rand = Random.Range(0, pDataSize);
        for (int i = 0; i < 3; i++)
            phraseData.setEmojis(emojiSets[rand, i], i);

        phraseData.setPhrase(phrases[rand]);

        return phraseData;
    }

    void Awake()
    {
        if (!database)
            database = this;

        //=Senders=
        emailSenders = new string[eDataSize]
        {
            "Whitehouse@gov.co.usa",
            "EnergyCorp@Qmail.com",
            "FutureTech@Qmail.com",
            "CIA-Secure@gov.co.usa",
            "Anon@Qmail.com"
        };
        //=========

        //=Subjects=
        emailSubjects = new string[eDataSize]
        {
            " We need your help!",
            " This could be interesting...",
            " New objective",
            " Run this experiment.",
            " Have a look at this"
        };
        //==========

        //=Greetings=
        emailGreetings = new string[eDataSize]
        {
            " Hello!",
            " Greetings, how are you, Sir?",
            " Sir!",
            " Hello again,",
            " Hey,"
        };
        //===========

        //=Bodies=
        emailBody = new string[eDataSize] 
        {
            " There has been a fatal disease outbreak and the Alien holds the key to stopping the deaths. Will you agree to a surgical operation to study the Alien's DNA & cells?",
            " A viral outbreak is killing many humans and animals but if we exploit the Alien's immune system we could produce an antivirus! Do you agree to the experiment?",
            " Help us advance technology by hurting the Alien.",
            " Save the animals by hurting the Alien.",
            " Experiment on the Alien to advance medical care for the sick."
        };
        //========

        //=Goodbye=
        emailGoodbye = new string[eDataSize] 
        {
            " Thanks, bye.",
            " Goodbye.",
            " Please choose quick!",
            " The sooner the better. Thanks.",
            " We would appreciate it, Sir."
        };
        //=========

        //=Phrases=
        phrases = new string[pDataSize] 
        {
            "abc",
            "abc_xyz",
            "abc_xyz_nop"
        };
        //=========

        emojiSets = new Sprite[pDataSize, pDataSize] 
        {
            { emoji1, emptyEmoji, emptyEmoji },
            { emoji1, emoji2, emptyEmoji },
            { emoji1, emoji2, emoji3 }
        };
    }
}
