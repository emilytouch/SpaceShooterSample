using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

    public Text gameOverText;
    public Boundary boundary;
    public int currentHealth;
    public float speed;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    // Use this for initialization
    void Start () {
        gameOverText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        //shooting button
        if (Input.GetButtonDown("Fire1") || Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

        if (currentHealth <= 0)
        {
            gameOverText.text = "Game Over";
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        //moving
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        GetComponent<Rigidbody2D>().velocity = movement * speed;

        //boundaries for player

        GetComponent<Rigidbody2D>().position = new Vector2(
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax)
            );
    }

    //player takes damage
    public void giveDamage(int enemyDamage)
    {
        currentHealth -= enemyDamage;
        GameObject.Find("GameController").GetComponent<GameController>().playerHealth -= enemyDamage;
        GameObject.Find("GameController").GetComponent<GameController>().SetHealthText();
    }
}
