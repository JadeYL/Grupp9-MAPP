using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour {

    public int Damage;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Terrain"))
        {
            Die();
        }
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovment>().hp -= 1;
            Die();
        }
    }
    private void Die()
    {
        Destroy(this.gameObject);
    }
}
