using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFX;
   

    private void OnTriggerEnter(Collider other)
    {
        startDeathSequence();

        Invoke("ReloadLevel",levelLoadDelay);

        print("Trigger");
    }

    private void startDeathSequence()
    {
        deathFX.SetActive(true);
        SendMessage("OnPlayerDeath");


    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
