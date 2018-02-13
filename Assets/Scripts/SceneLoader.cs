﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

        Invoke("LoadNewScene", 2f);

    }

    private void LoadNewScene()
    {
        SceneManager.LoadScene(1);
    }
}
