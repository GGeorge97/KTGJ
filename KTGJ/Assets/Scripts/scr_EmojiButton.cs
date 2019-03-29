using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_EmojiButton : MonoBehaviour
{
    [SerializeField]
    private Button button;
    private Text text;

    public static scr_EmojiEvent emojiEvent = new scr_EmojiEvent();

    private char[] buttonChar = new char[1]; 

    private void Start()
    {
        text = this.GetComponentInChildren<Text>();
        button = this.GetComponent<Button>();
        button.onClick.AddListener(OnClick);

        buttonChar[0] = text.text[0];
    }

    private void OnClick()
    {
        for (int i = 0; i < scr_EmojiEvent.phrase.Length; i++)
        {
            if (buttonChar[0] == scr_EmojiEvent.phrase[i])
            {
                //emojiEvent.codedString[i] = buttonChar[0];
                emojiEvent.UpdatePhrase(buttonChar[0], i);
                //Debug.Log("Change letter");
                //Debug.Log(emojiEvent.codedString[i]);
            }
        }
    }
}
