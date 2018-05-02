using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {
    public GameObject fireOrb;
    public GameObject boss;
    bool fireOrbTaken;
    Vector3 bossPos;
    float x;
    float y;
    float time;
	void Awake () {
        bossPos = boss.transform.position;
        fireOrbTaken = false;
        this.transform.position = boss.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if(fireOrbTaken == false)
        {
            x = Random.Range(-0.5f, 0.3f);
            y = Random.Range(-0.7f, -0.3f);
            Instantiate(fireOrb,boss.transform);
            fireOrb.transform.position = new Vector3(x, y, 0);
            
            fireOrbTaken = true;
        }
        if(fireOrbTaken == true)
        {
            time += Time.deltaTime;
            if(time >10)
            {
                fireOrbTaken = false;
                time = 0;
            }
        }
        

	}
}
