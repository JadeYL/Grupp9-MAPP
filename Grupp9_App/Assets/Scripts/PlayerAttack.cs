using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerAttack : MonoBehaviour {
    public Image powerUpImage;
    public Text text;
    public float damage;
    bool attacking;
    public float cd = 0.2f;
    bool onCD;
    float time;
    List<GameObject> targets = new List<GameObject>();
    bool fireOrb;

    // Use this for initialization
    void Awake()
    {
        time = 6;
        onCD = false;
        fireOrb = false;
    }

    // Update is called once per frame
    void FixedUpdate() {
        Debug.Log(fireOrb);
        
        if (cd > 0)
        {
            onCD = true;
            attacking = false;
            cd -= Time.deltaTime;
           
        }
        else if (cd <= 0)
        {
            GetComponentInParent<PlayerMovment>().moveSpeed = 0.07f;
            onCD = false;
            if (Input.GetKeyDown("e"))
            {
                attack();
                GetComponentInParent<PlayerMovment>().moveSpeed = 0.02f;
            }
            if (attacking == true )
            {
                foreach (GameObject go in targets)
                {
                go.GetComponent<EnemyHealth>().hp -= 1;
                go.GetComponent<EnemyHealth>().hit = true;
                    if(fireOrb == true)
                    {
                        go.GetComponent<TreeBossHP>().hp -= 1;
                    }
                }
                attacking = false;

                onCD = true;
                cd = 0.2f;
            }
        }

            if (fireOrb == true)
            {
                powerUpImage.enabled = true;
                text.enabled = true;
                time -= Time.deltaTime;
                text.text = time.ToString();
                if (time <= 0)
                {
                    powerUpImage.enabled = false;
                    text.enabled = false;
                    fireOrb = false;
                    time = 6;
                }
            }
        
        

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !targets.Contains(collision.gameObject))
        {
            targets.Add(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("PowerUp"))
        {
            fireOrb = true;
        }
        if(collision.gameObject.CompareTag("Boss"))
        {
            Debug.Log("Attack");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (GameObject v in targets)
        {
            if (targets.Contains(collision.gameObject))
            {
                targets.Remove(collision.gameObject);
            }
        }
    }
    public void attack()
    {
            attacking = true;
            
    }

}
