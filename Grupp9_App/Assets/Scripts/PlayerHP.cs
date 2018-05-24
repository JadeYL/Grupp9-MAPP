using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {
    public int hp = 20;
    public Slider healthBar;
    public Text deathCounter;
    int death;

	// Use this for initialization
	void Start () {
        int death = 0;
    }
	
	// Update is called once per frame
	void Update () {

        healthBar.value = hp;
        if (hp <= 0)
        {
            respawn();
        }
        deathCounter.text = death.ToString();
	}
    void respawn(){
        hp = 20;
        death++;
    }
  
}
