using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name=="MatchMaking")
        {
            gameObject.GetComponent<AudioSource>().enabled = false;
        }
        else if (SceneManager.GetActiveScene().name=="Home")
        {
            gameObject.GetComponent<AudioSource>().enabled = true;
        }
    }
}
