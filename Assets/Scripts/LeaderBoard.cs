using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
    public TMP_Text text;
    public PlayerScore player;
    public float finalScore;

    string ScoreKey = "Score";

    void Start()
    {
        player = GetComponent<PlayerScore>();
        
        LoadPrefs();

        text.text = PlayerPrefs.GetInt("Score",0).ToString();
    }
    public void LoadPrefs()
    {
        finalScore = PlayerPrefs.GetFloat(ScoreKey, 0);
    }
}
