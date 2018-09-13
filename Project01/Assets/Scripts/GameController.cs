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
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
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
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
	}

    IEnumerator WaitSpawner()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            randEnemy = Random.Range(0, 9);
            Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), 11);
            Instantiate(enemies[randEnemy], spawnPosition, gameObject.transform.rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
