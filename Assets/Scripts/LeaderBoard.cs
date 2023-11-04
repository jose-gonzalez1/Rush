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

        // finalScore = player.score;
        text.text = finalScore.ToString();
        // Debug.Log(finalScore);
    }
    public void LoadPrefs()
    {
        finalScore = PlayerPrefs.GetFloat(ScoreKey, 0);
    }
}
