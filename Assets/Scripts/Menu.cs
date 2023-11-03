using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayButton () 
    {
        StartCoroutine(test(1.5f));
    }

    public void OnQuitButton ()
    {
        Application.Quit();
    }

    private IEnumerator test(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
    }
}
