using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour {

    //public GameObject player;
    PlayerMovment playerScript;
    public GameObject player;
    Vector3 targetPos;
    Vector3 oldtarget;
    PolygonCollider2D hitBox;
    bool attacking;
    float time;

	// Use this for initialization
	void Start () {
        hitBox = this.gameObject.GetComponent<PolygonCollider2D>();
        attacking = false;
	}
	
	// Update is called once per frame
	void Update () {
        float tempX;
        float tempY;
        time = Time.time;
        targetPos.x = player.transform.position.x - transform.position.x;
        targetPos.y = player.transform.position.y - transform.position.y;
        tempX = targetPos.x;
        tempY = targetPos.y;
        if(targetPos.x < 0)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        if (attacking == false)
        {
            transform.position += targetPos * 0.5f * Time.deltaTime;
        }
       
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            attacking = true;
            playerScript = player.GetComponent<PlayerMovment>();
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        time = Time.time;
        Debug.Log(time);
       
        if (time > 1.5f)
        {
            playerScript.hp -= 1;
            time = 0;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        attacking = false;
        time = 0;
    }
}
