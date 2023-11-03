using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timer;
    public float timeLeft = 10;
    public bool startTimer = false;
    private void Start()
    {
        startTimer = true;   
    }
    void Update()
    {
        updateTimer(timeLeft);
        if (startTimer)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timeLeft = 0;
                startTimer = false;
            }
        }
    }

    void updateTimer(float time)
    {
        float seconds = Mathf.FloorToInt(time % 60);
        timer.text = string.Format("{0:00} seconds remaining",seconds);
    }

}
