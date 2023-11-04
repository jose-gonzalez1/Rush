using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timer;
    public float timeLeft = 100;
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
            timeLeft += Time.deltaTime;
        }
    }

    void updateTimer(float time)
    {
        float seconds = Mathf.FloorToInt(time % 60);
        timer.text = string.Format("{0:00} seconds remaining",seconds);
    }

}
