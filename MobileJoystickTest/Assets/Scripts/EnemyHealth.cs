using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int hp;
    public bool hit;
    private SpriteRenderer sR;
    float time;
	// Use this for initialization
	void Start ()
    {
        hit = false;
      sR = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            sR.color = Color.white;
        }
		if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
        if (hit == true)
        {
            time = 0.1f;
            sR.color = Color.red;
        //    transform.position += -gameObject.GetComponent<MeleeEnemy>().targetPos.normalized * 0.2f;
            hit = false;
        }
        
	}
    
}
