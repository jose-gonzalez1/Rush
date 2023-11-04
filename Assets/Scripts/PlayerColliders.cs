using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] public bool CheckpointSecured = false;
    Transform pos;

    PlayerScore player;

    string ScoreKey = "Score";

    public float timeAccumalated = 0;
    public bool startTimer = false;



    void Start()
    {
        startTimer = true;
        player = GetComponent<PlayerScore>();
        if( SceneManager.GetActiveScene().buildIndex == 1)
        {
            SavePrefs();
        }       
        LoadPrefs();
        pos = GetComponent<Transform>();
    }

    void Update()
    {
        timeAccumalated += Time.deltaTime;
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetFloat(ScoreKey, player.score);
        PlayerPrefs.Save();
    }

    public void LoadPrefs()
    {
        player.score = PlayerPrefs.GetFloat(ScoreKey, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            pos.position = new Vector2(-7f,-0.5f);
            GameObject.Find("Finish").GetComponent<Renderer>().material.color = new Color(99,99,99,0);//Grey
            CheckpointSecured = false;
            Debug.Log("Trap");
        }

        else if (collision.gameObject.CompareTag("Checkpoint"))
        {
            GameObject.Find("Finish").GetComponent<Renderer>().material.color = new Color(0,255,0,254);//Green
            CheckpointSecured = true;
            Debug.Log("Checkpoint");
        }

        else if (collision.gameObject.CompareTag("Finish") && CheckpointSecured)
        {
            timeAccumalated = Mathf.FloorToInt(timeAccumalated % 60);
            player.score = player.score - (10 * timeAccumalated);
            SavePrefs();
            Debug.Log(player.score);
            Debug.Log(timeAccumalated);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
