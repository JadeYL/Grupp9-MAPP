using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBossHP : MonoBehaviour {
    public  GameObject fireOrb;
    bool take;
    float time;
    int onlyOne;
    public int hp;
	// Use this for initialization
	void Start () {
        hp = 10;
        time = 0;
        take = false;
        onlyOne = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(time);
        Debug.Log(hp);
        if (take == false)
        {

            float x = Random.Range(-2.4f, 1.8f);
            float y = Random.Range(-1.3f, -2f);
            Instantiate(fireOrb, this.transform);
            fireOrb.transform.position = new Vector3(x, y, 0);
            take = true;
        }
        if (take == true)
        {
            time += Time.deltaTime;
            if (time> 16)
            {
                take = false;
            }
        }
        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
