using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayMusic : MonoBehaviour {

    void Awake()
    {
        int numOfMusicPlayers = FindObjectsOfType<PlayMusic>().Length;

        if (numOfMusicPlayers > 1)
        {
            Destroy(gameObject);
        } 
        else
        {
            //doesn't destroy the gameObject the script is attached to
            DontDestroyOnLoad(transform.gameObject);
        }
    }

}
