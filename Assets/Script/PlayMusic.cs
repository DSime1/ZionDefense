using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayMusic : MonoBehaviour {

    void Awake()
    { //doesn't destroy the gameObject the script is attached to
        DontDestroyOnLoad(transform.gameObject);
    }

	// Use this for initialization
	void Start () {
        

	}
}
