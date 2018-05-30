using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour {

    public GameObject bullet;
    public float fireRate = 3f;
    private float nextFire = 0f;

    void Start () {
		
	}
	
	
	void Update () {
        
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bulletInstance = (GameObject)Instantiate(bullet, transform.position + new Vector3(0.5f * transform.localScale.x, 1f, 0f), Quaternion.identity);
            bulletInstance.GetComponent<turretShot>().facingRight = transform.localScale.x;
            
        }
    }
}
