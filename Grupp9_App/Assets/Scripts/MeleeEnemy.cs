using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{

    //public GameObject player;
    PlayerMovment playerScript;
    public GameObject player;
    public  Vector3 targetPos;
    Vector3 oldtarget;
    PolygonCollider2D hitBox;
    bool attacking;
    float time;
    float angle;
    public float maxDistance;
    public float minDistance;

    // Use this for initialization
    void Start()
    {
        hitBox = this.gameObject.GetComponent<PolygonCollider2D>();
        attacking = false;
        time = 0;

        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        time += Time.deltaTime;
        targetPos.x = player.transform.position.x - transform.position.x;
        targetPos.y = player.transform.position.y - transform.position.y;

        if (targetPos.x < maxDistance && targetPos.y < maxDistance && targetPos.x > minDistance && targetPos.y > minDistance)
        {
            if (targetPos.x < 0)
            {
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            else
            {
                transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }
            if (attacking == false)
            {
               targetPos = targetPos.normalized;
                transform.position += targetPos * 1f * Time.deltaTime;
            }
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
       // Debug.Log(time);
        if (collision.gameObject.CompareTag("Player"))
        {
            attacking = true;
            if (time > 1.5f)
            {
                collision.GetComponent<PlayerMovment>().hp -= 1;
                time = 0;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        attacking = false;
        time = 0;
    }
}

