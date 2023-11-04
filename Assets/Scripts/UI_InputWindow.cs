using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UI_InputWindow : MonoBehaviour
{
    public TMP_InputField ifif;

    public TMP_Text text;
    string input;

    string allowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    public struct ScoreObject {
        public string userID;
        public string score; 
    }

    ScoreObject curPlayer;




    public void OnSubmitButton( string s)
    {
        if (Input.GetKeyDown(KeyCode.Return)){
            Debug.Log("Return was clicked");
            curPlayer.userID = s;
            curPlayer.score = text.text;
            Debug.Log("from UI Script "+ curPlayer.userID);
            Debug.Log("from UI Script "+ curPlayer.score);
            // Hide();
        }
    }

    public void OnValueChange(string c)
    {   
        if (c.Length == 1 && !isAllowed(c[0], allowedCharacters, allowedCharacters.Length)){
            ifif.text = c.Substring(0, c.Length - 1 );
        }
        else if ( c.Length > 1 && !isAllowed(c[c.Length - 1], allowedCharacters, allowedCharacters.Length)){
            ifif.text = c.Substring(0, c.Length - 1 );
        }
    }

    bool isAllowed(char c, string s, int sLength){
        for ( int ix = 0; ix < sLength; ix++ ){
            if ( c == s[ix] ){
                return true;
            }
        }
        return false;
    }
    public void Awake()
    {
        Show();
        ifif.characterLimit = 3;
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
