using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Collider enemyboxCollider = new Collider();

    [SerializeField] int scorePerHit = 12;
    [SerializeField] int Health = 20;

    [SerializeField] GameObject deathFX;

    [SerializeField] Transform parent;

    ScoreBoard scoreBoard;
 

    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scorePerHit);

        Health = --Health;

        //todo consider adding bullet collision sound
        if (Health <= 0)
        {
            KillEnemy();
        } 
    }

    private void KillEnemy()
    {
        //Adding explosion effect 'deathFX' to enemy ship
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        print("enemyHit: " + gameObject.name);

        //giving the deathFx objects a parent object 'parent' in the hierarchy
        fx.transform.parent = parent;
    }

    // Use this for initialization
    void Start ()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();


        //if the game object already has a boxcollider then don't add
        if (!gameObject.GetComponent<BoxCollider>())
        {
            AddBoxCollider();    
        } 

    }

    private void AddBoxCollider()
    {
        enemyboxCollider = gameObject.AddComponent<BoxCollider>();
        enemyboxCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
