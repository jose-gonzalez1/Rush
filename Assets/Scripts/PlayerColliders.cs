using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] public bool CheckpointSecured = false;
    Transform pos;

    void Start()
    {
        pos = GetComponent<Transform>();
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
