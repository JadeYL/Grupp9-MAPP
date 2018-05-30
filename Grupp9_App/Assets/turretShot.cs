using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretShot : MonoBehaviour {

    public float facingRight;
    public float speed = 1f;
    public float bulletTimer = 10;
    
    void Start () {
        
	}
	
	
	void Update () {
        transform.Translate(Vector3.right * facingRight * Time.deltaTime * speed);
        bulletTimer -= Time.deltaTime;
        if (bulletTimer < 0)
        {
            Destroy(gameObject);

        }

    }
}
