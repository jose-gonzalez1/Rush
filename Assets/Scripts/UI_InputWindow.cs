using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using System;
public class UI_InputWindow : MonoBehaviour
{
    public TMP_InputField ifif;
    public TMP_Text text;
    public TMP_Text leaderboard;
    string input;


    public PlayerScore player;

    string allowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    public void OnSubmitButton(string s)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Return was clicked");
            if (PlayerPrefs.GetInt("Score", 0) > PlayerPrefs.GetInt("HighscoreScore", 0))
            {
                Debug.Log(s);
                PlayerPrefs.SetString("HighscoreID", s);
                PlayerPrefs.SetInt("HighscoreScore", PlayerPrefs.GetInt("Score", 0));
                PlayerPrefs.Save();
            }
            
            Hide();
            leaderboard.gameObject.SetActive(true);
        }
    }

    public void OnValueChange(string c)
    {
        if (c.Length == 1 && !isAllowed(c[0], allowedCharacters, allowedCharacters.Length))
        {
            ifif.text = c.Substring(0, c.Length - 1);
        }
        else if (c.Length > 1 && !isAllowed(c[c.Length - 1], allowedCharacters, allowedCharacters.Length))
        {
            ifif.text = c.Substring(0, c.Length - 1);
        }
    }
    bool isAllowed(char c, string s, int sLength)
    {
        for (int ix = 0; ix < sLength; ix++)
        {
            if (c == s[ix])
            {
                return true;
            }
        }
        return false;
    }
    public void Awake()
    {
        ifif.characterLimit = 3;
        int savedScore = PlayerPrefs.GetInt("HighscoreScore", 0);
        int curScore = PlayerPrefs.GetInt("Score", 0);
        Debug.Log("saved score" + savedScore);
        Debug.Log("cur score" + curScore);
        Show();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
