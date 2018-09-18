using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public int enemyHealth;
    public float enemySpeed;
    public int scoreValue;
    public int enemyDamage = 1;
    public GameObject enemy;

    //powerups
    public GameObject[] powerUps;
    int randPU;
    public int addHealth;
    public int addPower;

	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    //how enemy gets destroyed
    void Update () {

        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, enemySpeed);
        if (enemyHealth <= 0 && gameObject.tag == "Enemy")
        {
            //scores!!
            GameObject.Find("GameController").GetComponent<GameController>().score = GameObject.Find("GameController").GetComponent<GameController>().score + scoreValue;
            GameObject.Find("GameController").GetComponent<GameController>().SetScoreText();
            Destroy(gameObject);
            randPU = Random.Range(0, 5);
            Instantiate(powerUps[randPU], enemy.transform.position, enemy.transform.rotation);
        }
	}

    //when enemy gets hit
    public void giveDamage(int damage)
    {
        enemyHealth -= damage;
    }

    //when enemy hits player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && gameObject.tag == "Enemy")
        {
            other.GetComponent<PlayerController>().giveDamage(enemyDamage);
        }

        if (other.tag == "Player" && gameObject.tag == "powerUp")
        {
            GameObject.Find("Player").GetComponent<PlayerController>().damage += addPower;
            GameObject.Find("GameController").GetComponent<GameController>().playerHealth += addHealth;
            GameObject.Find("GameController").GetComponent<GameController>().SetHealthText();
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
