﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public int damage;
    

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().giveDamage(damage);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
