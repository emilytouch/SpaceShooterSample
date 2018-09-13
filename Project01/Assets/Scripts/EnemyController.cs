using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public int enemyHealth;
    public float enemySpeed;
    public int scoreValue;
    public int enemyDamage = 1;

    //public GameObject enemy;

	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    //how enemy gets destroyed
    void Update () {

        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, enemySpeed);
        if (enemyHealth <= 0)
        {
            //scores!!
            GameObject.Find("GameController").GetComponent<GameController>().score = GameObject.Find("GameController").GetComponent<GameController>().score + scoreValue;
            GameObject.Find("GameController").GetComponent<GameController>().SetScoreText();
            Destroy(gameObject);
        }
	}

    //when enemy gets hit
    public void giveDamage(int damage)
    {
        enemyHealth -= damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().giveDamage(enemyDamage);
        }
    }
}
