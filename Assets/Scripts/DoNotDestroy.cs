using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] music = GameObject.FindGameObjectsWithTag("GameMusic");
        if( music.Length > 1 )
        {
            Destroy(music[0]);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
