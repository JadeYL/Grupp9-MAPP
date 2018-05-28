using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerAttack : MonoBehaviour
{
    private GameObject powerUpImage;
    private GameObject text;
    public float damage;
    bool attacking;
    public float cd = 0.2f;
    bool onCD;
    float time;
    List<GameObject> targets = new List<GameObject>();
    bool fireOrb;
    bool bossAttack;

    // Use this for initialization
    void Start()
    {
        powerUpImage = GameObject.FindGameObjectWithTag("PowerUpIcon");
        text = GameObject.FindGameObjectWithTag("PowerUpTimer");
        time = 6;
        onCD = false;
        fireOrb = false;
        bossAttack = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

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
            if (attacking == true)
            {
                foreach (GameObject go in targets)
                {
                    go.GetComponent<EnemyHealth>().hp -= 1;
                    go.GetComponent<EnemyHealth>().hit = true;
                }
                attacking = false;

                onCD = true;
                cd = 0.2f;
            }
        }
        if (fireOrb == true)
        {
            powerUpImage.SetActive(true);
            time -= Time.deltaTime;
            if (time <= 0)
            {
                powerUpImage.SetActive(false);
                fireOrb = false;
                time = 6;
            }
        }
        else
        {
            powerUpImage.SetActive(false);
        }



    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !targets.Contains(collision.gameObject))
        {
            targets.Add(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            fireOrb = true;
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            Debug.Log("FIRST ATTACK");
            if(bossAttack == true)
            {
                Debug.Log("SECOND ATTACK");
                collision.gameObject.GetComponent<TreeBossHP>().hp -= 1;
                bossAttack = false;
            }
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
        if( fireOrb == true)
            bossAttack = true;

    }

}
