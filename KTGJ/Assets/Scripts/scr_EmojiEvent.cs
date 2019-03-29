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

    private Sprite[] emojis = new Sprite[3];
    public Sprite[] getEmojis() { return emojis; }
    public void setEmojis(Sprite[] setVal) { emojis = setVal; }

    private string phrase; 
    public string getPhrase() { return phrase; }
    public void setPhrase(string setVal) { phrase = setVal; }

    private GameObject emojiPanel;
    private GameObject emojiText;
    private GameObject emojiKeyboard; 

    private char[] codedString = new char[50]; 

    private void RunEmojiEvent()
    {
        // Get emoji data from database 
        scr_Database.PhraseData phraseData = scr_Database.database.RetrievePhrase();

        // Setters 
        setEmojis(phraseData.getEmojis());
        setPhrase(phraseData.getPhrase());

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
}
