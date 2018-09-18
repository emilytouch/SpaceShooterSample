using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //UI stuff
    public Text healthText;
    public Text scoreText;
    public int playerHealth;
    public int score;

    //spawning enemies
    public GameObject[] enemies;
    public Vector2 spawnValues;
    public float spawnWait = 3f;
    public float spawnVar = 1f;
    public float spawnInc = -0.1f;
    public int startWait;
    int randEnemy;


    // Use this for initialization
    void Start () {
        score = 0;
        SetScoreText();
        SetHealthText();
        playerHealth = 3;

        StartCoroutine(WaitSpawner());
	}

    //score text
    public void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    //health text
    public void SetHealthText()
    {
        healthText.text = "Health: " + playerHealth.ToString();
    }
	// Update is called once per frame
	void Update () {

	}

    IEnumerator WaitSpawner()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            randEnemy = Random.Range(0, 9); //gives different enemies different chances of spawning
            Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), 11); //area where they spawn
            Instantiate(enemies[randEnemy], spawnPosition, gameObject.transform.rotation); //actually spawning
            yield return new WaitForSeconds(spawnWait + Random.value * spawnVar); //wait time

            //faster spawn time as time goes on
            if (spawnWait - spawnInc > 0.5)
            {
                spawnWait -= spawnInc;
            }
            if (spawnWait <= 0.5)
            {
                spawnWait = 0.5f;
            }
        }
    }
}
