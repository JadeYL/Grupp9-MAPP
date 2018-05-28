using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeBossHP : MonoBehaviour {
    public  GameObject fireOrb;
    public GameObject healthBar;
    private Slider slider;
    bool take;
    float time;
    int onlyOne;
    public int hp;
	// Use this for initialization
	void Awake () {
        hp = 100;
        time = 0;
        take = false;
        onlyOne = 0;
        slider = healthBar.GetComponent<Slider>();
        slider.value = hp;
        healthBar.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if(GetComponentInParent<TreeBossController>().playerInArea == true)
        {
            healthBar.SetActive(true);
            slider.value = hp;
        }
        else
        {
            healthBar.SetActive(false);
        }
        if(hp <= 0)
        {
            healthBar.SetActive(false);
        }
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
                 time = 0;
            }
        }
        if(hp <= 0)
        {
            Destroy(transform.parent.gameObject);
        }

    }
}
