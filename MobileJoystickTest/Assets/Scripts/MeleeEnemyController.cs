using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour {

    //public GameObject player;
    public PlayerMovment player;
    Vector3 targetPos;
    Vector3 oldtarget;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float tempX;
        float tempY;

        targetPos.x = player.transform.position.x - transform.position.x;
        targetPos.y = player.transform.position.y - transform.position.y;
        tempX = targetPos.x;
        tempY = targetPos.y;
       
        transform.position += targetPos * 0.01f;
		
	}
}
