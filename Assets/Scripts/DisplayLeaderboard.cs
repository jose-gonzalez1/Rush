using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System;


public class DisplayLeaderboard : MonoBehaviour
{
    public TMP_Text text;

    public string ParseString;

    public string leaderboardString;
   

    public void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Start()
    {
        string temp = "testing...";
        temp = PlayerPrefs.GetString("HighscoreID","");
        temp += "\t";
        temp += Convert.ToString(PlayerPrefs.GetInt("HighscoreScore",0));
        text.text = temp;
    }

}
