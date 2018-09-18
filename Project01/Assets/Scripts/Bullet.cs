using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    

    // Use this for initialization
    void Start () {
        
	}
	
    //making bullet go zoom
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, speed);
    }

    //kill enemies with this and destroying on contact
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().giveDamage(GameObject.Find("Player").GetComponent<PlayerController>().damage);
            Destroy(gameObject);
        }
    }

    //destroying bullet off screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
