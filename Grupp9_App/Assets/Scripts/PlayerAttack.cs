using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerAttack : MonoBehaviour {
    public float damage;
    bool attacking;
    public float cd = 0.2f;
    bool onCD;
    List<GameObject> targets = new List<GameObject>();
    bool fireOrb;

    // Use this for initialization
    void Awake()
    {
        onCD = false;
        fireOrb = GetComponentInParent<PlayerMovment>().fireOrb;
    }

    // Update is called once per frame
    void FixedUpdate() {

        
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
                        go.GetComponent<TreeBossController>().hp -= 1;   
                    }
                }
                attacking = false;
                Debug.Log(attacking);
                onCD = true;
                cd = 0.2f;
            }
        }
        

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !targets.Contains(collision.gameObject))
        {
            targets.Add(collision.gameObject);
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
