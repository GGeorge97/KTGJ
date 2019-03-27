using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_Database : MonoBehaviour
{
    // Static reference
    public static scr_Database database;

    public struct EmailData // CHOICES
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
        private string timeRecieved;
        public string getTimeRecieved() { return timeRecieved; }
        public void setTimeRecieved(string i) { timeRecieved = i; }
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

        emailData.setTimeRecieved(gameClock[gameTimeIndex]);

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

    public struct SpamData  // SPAM
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
        private string timeRecieved;
        public string getTimeRecieved() { return timeRecieved; }
        public void setTimeRecieved(string i) { timeRecieved = i; }
    }

    private const int sDataSize = 5;
    private string[] spamSenders;
    private string[] spamSubjects;
    private string[] spamGreetings;
    private string[] spamBody;
    private string[] spamGoodbye;

    public SpamData GenerateSpamData()
    {
        SpamData spamData = new SpamData();

        Random.InitState(System.Environment.TickCount);

        int rand = Random.Range(0, sDataSize);
        spamData.setSender(spamSenders[rand]);

        rand = Random.Range(0, sDataSize);
        spamData.setSubject(spamSubjects[rand]);

        spamData.setTimeRecieved(gameClock[gameTimeIndex]);

        string msg = "";
        rand = Random.Range(0, sDataSize);
        msg += spamGreetings[rand];
        rand = Random.Range(0, sDataSize);
        msg += spamBody[rand];
        rand = Random.Range(0, sDataSize);
        msg += spamGoodbye[rand];
        spamData.setMessage(msg);

        return spamData;
    }

    public struct TutorialData  // TUTORIALS
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
        private string timeRecieved;
        public string getTimeRecieved() { return timeRecieved; }
        public void setTimeRecieved(string i) { timeRecieved = i; }
    }

    private const int tDataSize = 5;
    private int tutorialIndex = 0;
    private string[] tutorialSenders;
    private string[] tutorialSubjects;
    private string[] tutorialGreetings;
    private string[] tutorialBody;
    private string[] tutorialGoodbye;

    public TutorialData GenerateTutorialData()
    {
        TutorialData tutorialData = new TutorialData();

        tutorialData.setSender(tutorialSenders[tutorialIndex]);
        tutorialData.setSubject(tutorialSubjects[tutorialIndex]);
        tutorialData.setTimeRecieved(gameClock[gameTimeIndex]);

        string msg = "";
        msg += tutorialGreetings[tutorialIndex];
        msg += tutorialBody[tutorialIndex];
        msg += tutorialGoodbye[tutorialIndex];
        tutorialData.setMessage(msg);

        if(tutorialIndex < tDataSize - 1)
            tutorialIndex++;

        return tutorialData;
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


    private string[] gameClock;
    public string getGameClock(int i) { return gameClock[i]; }

    void Awake()
    {
        if (!database)
            database = this;

        //=Senders=
        emailSenders = new string[eDataSize]
        {
            "Whitehouse@gov.co.us",
            "EnergyCorp@Qmail.com",
            "FutureTech@Qmail.com",
            "CIA-Secure@gov.co.us",
            "Anon@Qmail.com"
        };
        spamSenders = new string[sDataSize]
        {
            "",
            "",
            "",
            "",
            ""
        };
        tutorialSenders = new string[tDataSize]
{
            "Whitehouse@gov.co.us",
            "",
            "",
            "",
            ""
};
        //=========

        //=Subjects=
        emailSubjects = new string[eDataSize]
        {
            " We need your help!",
            " This could be interesting...",
            " New objective",
            " Run this experiment...",
            " Have a look at this"
        };
        spamSubjects = new string[sDataSize]
        {
            " ",
            " ",
            " ",
            " ",
            " "
        };
        tutorialSubjects = new string[sDataSize]
        {
            "Your Mission, Commander:",
            " ",
            " ",
            " ",
            " "
        };
        //==========

        //=Greetings=
        emailGreetings = new string[tDataSize]
        {
            " Hello!",
            " Hello, how are you?",
            " Hey!",
            " Hello again.",
            " Greetings."
        };
        spamGreetings = new string[sDataSize]
        {
            " ",
            " ",
            " ",
            " ",
            " "
        };
        tutorialGreetings = new string[tDataSize]
        {
            "Greetings, Commander.",
            " ",
            " ",
            " ",
            " "
        };
        //===========

        //=Bodies=
        emailBody = new string[eDataSize] 
        {
            " There has been a fatal disease outbreak and the Alien holds the key to stopping the deaths.\nWill you agree to a surgical operation to study the Alien's DNA & cells?",
            " A viral outbreak is killing many humans and animals but if we exploit the Alien's immune system we could produce an antivirus!\nDo you agree to the experiment?",
            " Help us advance technology by hurting the Alien.",
            " Save the animals by hurting the Alien.",
            " Experiment on the Alien to advance medical care for the sick."
        };
        spamBody = new string[sDataSize]
        {
            " ",
            " ",
            " ",
            " ",
            " "
        };
        tutorialBody = new string[tDataSize]
        {
            "\nYou are tasked with monitoring the specimen held in containment within your laboratory. We have intercepted transmissions which indicate that the alien Mothership is en route to Earth and their intentions are unclear. We will keep in contact through the email system for your approval of certain alien experiments. These experiments will greatly benefit Humanity. Make sure to keep the alien safe and happy.",
            " ",
            " ",
            " ",
            " "
        };
        //========

        //=Goodbye=
        emailGoodbye = new string[eDataSize] 
        {
            "\nThank you for your help.",
            "\nWe need your signature!",
            "\nPlease choose quick!",
            "\nThe sooner the better. Thanks.",
            "\nWe would appreciate it."
        };
        spamGoodbye = new string[sDataSize]
        {
            " ",
            " ",
            " ",
            " ",
            " "
        };
        tutorialGoodbye = new string[tDataSize]
        {
            "\nGood luck, Commander.",
            " ",
            " ",
            " ",
            " "
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

        gameClock = new string[]
{
            "00:00", "00:15", "00:30", "00:45",
            "01:00", "01:15", "01:30", "01:45",
            "02:00", "02:15", "02:30", "02:45",
            "03:00", "03:15", "03:30", "03:45",
            "04:00", "04:15", "04:30", "04:45",
            "05:00", "05:15", "05:30", "05:45",
            "06:00", "06:15", "06:30", "06:45",
            "07:00", "07:15", "07:30", "07:45",
            "08:00", "08:15", "08:30", "08:45",
            "09:00", "09:15", "09:30", "09:45",
            "10:00", "10:15", "10:30", "10:45",
            "11:00", "11:15", "11:30", "11:45",
            "12:00", "12:15", "12:30", "12:45",
            "13:00", "13:15", "13:30", "13:45",
            "14:00", "14:15", "14:30", "14:45",
            "15:00", "15:15", "15:30", "15:45",
            "16:00", "16:15", "16:30", "16:45",
            "17:00", "17:15", "17:30", "17:45",
            "18:00", "18:15", "18:30", "18:45",
            "19:00", "19:15", "19:30", "19:45",
            "20:00", "20:15", "20:30", "20:45",
            "21:00", "21:15", "21:30", "21:45",
            "22:00", "22:15", "22:30", "22:45",
            "23:00", "23:15", "23:30", "23:45",
        };
    }

    private int gameTimeIndex = 9;
    private float gameTimeCount = 0.0f;
    private void Update()
    {
        gameTimeCount += Time.deltaTime;
        if (gameTimeCount > 10.0f)
        {
            gameTimeCount = 0.0f;
            if (gameTimeIndex < gameClock.Length - 1)
                gameTimeIndex++;
            else
                gameTimeIndex = 0;
        }
    }
}
