using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_EmojiEvent : MonoBehaviour
{
    [SerializeField]
    private GameObject emojiPanelPrefab;
    [SerializeField]
    private GameObject emojiTextPrefab;
    [SerializeField]
    private GameObject emojiKeyboardPrefab;
    [SerializeField]
    private GameObject buttonPrefab;

    private Sprite[] emojis = new Sprite[3];
    public Sprite[] getEmojis() { return emojis; }
    public void setEmojis(Sprite[] setVal) { emojis = setVal; }

    public static string phrase;
    public string getPhrase() { return phrase; }
    public void setPhrase(string setVal) { phrase = setVal; }

    private GameObject emojiPanel;
    public static GameObject emojiText;
    private GameObject emojiKeyboard;
    private GameObject[] buttons = new GameObject[25];

    public char[] codedString = new char[50];
    private char[] shuffle;

    private string help;

    private void Start()
    {
        emojiPanel = Instantiate(emojiPanelPrefab);
        emojiText = Instantiate(emojiTextPrefab);

        help = emojiTextPrefab.GetComponentInChildren<Text>().text;
    }

    private void RunEmojiEvent()
    {
        // Get emoji data from database 
        scr_Database.PhraseData phraseData = scr_Database.database.RetrievePhrase();

        // Setters 
        setEmojis(phraseData.getEmojis());
        setPhrase(phraseData.getPhrase());

        shuffle = phrase.ToCharArray();
        for (int i = 0; i < phrase.Length; i++)
        {
            if (phrase[i] == '_')
            {
                shuffle[i] = phrase[i + 1];
                i++;
            }
        }
        Shuffle();

        //Debug.Log(emojis[0]);
        //Debug.Log(emojis[1]);
        //Debug.Log(emojis[2]);
        Debug.Log(phrase);

        // Spawn prefabs with data 
        emojiPanel = Instantiate(emojiPanelPrefab, GameObject.Find("EmojiScreen").transform);
        emojiPanel.GetComponentInChildren<scr_Emoji>().setEmojis(emojis[0], emojis[1], emojis[2]);

        emojiText = Instantiate(emojiTextPrefab, GameObject.Find("EmojiScreen").transform);
        EncodeText();

        emojiKeyboard = Instantiate(emojiKeyboardPrefab, GameObject.Find("EmojiScreen").transform);

        // Create buttons with phrase letters on them
        for (int i = 0; i < phrase.Length; i++)
        {
            buttons[i] = Instantiate(buttonPrefab, emojiKeyboard.transform);
            buttons[i].transform.Translate(i * 75.0f, 0.0f, 0.0f);
            buttons[i].GetComponentInChildren<Text>().text = shuffle[i].ToString();
        }
    }

    private void Shuffle()
    {
        for (int i = 0; i < shuffle.Length; i++)
        {
            char temp = shuffle[i];

            int rand = Random.Range(0, shuffle.Length);
            shuffle[i] = shuffle[rand];
            shuffle[rand] = temp;
        }
    }

    private void EncodeText()
    {
        // Encode phrase
        for (int i = 0; i < phrase.Length; i++)
        {
            if (phrase[i] == '_')
            {
                codedString[i] = ' ';
                emojiText.GetComponentInChildren<Text>().text += codedString[i].ToString() + " ";
            }
            else
            {
                codedString[i] = '_';
                emojiText.GetComponentInChildren<Text>().text += codedString[i].ToString() + " ";
            }
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Destroy(emojiPanel);
            Destroy(emojiText);
            Destroy(emojiKeyboard);
            RunEmojiEvent();
        }
    }

    public void Update()
    {
        HandleInput();
    }

    public void UpdatePhrase(char letter, int x)
    {
        // Should be able to change letter and update the string so the user can see the phrase update 
        codedString[x] = letter;
        Debug.Log(codedString[x]);

        emojiText.GetComponentInChildren<Text>().text = " ";

        for (int i = 0; i < phrase.Length; i++)
        {
            //help += codedString[i].ToString() + " ";
            emojiText.GetComponentInChildren<Text>().text += codedString[i].ToString() + " ";
            Debug.Log(codedString[i]);
        }
    }
}
