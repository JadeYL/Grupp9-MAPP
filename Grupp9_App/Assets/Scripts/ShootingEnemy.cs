using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour {

    public GameObject player;
    public Rigidbody2D bullet;
    public Vector3 targetPos;
    private float time2;
    public float fireRate;
    public float maxDistance;
    public float minDistance;
	// Use this for initialization
	void Start () {
        fireRate = 3;
    }

    // Update is called once per frame
    void Update () {
        time2 += Time.deltaTime;
        targetPos = player.transform.localPosition - transform.position;
        if (targetPos.x < maxDistance && targetPos.y < maxDistance && targetPos.x > minDistance && targetPos.y > minDistance)
        {
            if (time2 > fireRate)
            {
                shoot();
                time2 = 0;
            }
        }
	}
    void shoot()
    {
        Rigidbody2D bulletCLone = (Rigidbody2D)Instantiate(bullet, transform.position, transform.rotation );
        Debug.DrawLine(transform.position, player.transform.localPosition,Color.white,2f);
        targetPos = targetPos.normalized;
        bulletCLone.velocity = targetPos * 2f;
    }
}
