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
        emailData.setSubject(emailSenders[rand]);

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
            "1",
            "2",
            "3",
            "4",
            "5"
        };
        //=========

        //=Subjects=
        emailSubjects = new string[eDataSize]
        {
            "1",
            "2",
            "3",
            "4",
            "5"
        };
        //==========

        //=Greetings=
        emailGreetings = new string[eDataSize]
        {
            "1",
            "2",
            "3",
            "4",
            "5"
        };
        //===========

        //=Bodies=
        emailBody = new string[eDataSize] 
        {
            "1",
            "2",
            "3",
            "4",
            "5"
        };
        //========

        //=Goodbye=
        emailGoodbye = new string[eDataSize] 
        {
            "1",
            "2",
            "3",
            "4",
            "5"
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
