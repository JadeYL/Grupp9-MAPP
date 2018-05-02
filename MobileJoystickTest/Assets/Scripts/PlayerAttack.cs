using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerAttack : MonoBehaviour {
    public float damage;
    bool attacking;
    public float cd = 0.3f;
    bool onCD;
    List<GameObject> targets = new List<GameObject>();
    bool fireOrb;
    int i = 0;

    // Use this for initialization
    void Awake() {
           }

    // Update is called once per frame
    void Update() {
        fireOrb = GetComponentInParent<PlayerMovment>().fireOrb;
        if (cd > 0)
        {
            onCD = true;
            attacking = false;
            cd -= Time.deltaTime;
        }
        else if (cd <= 0)
        {
            onCD = false;
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("Hit");
                attack();
            }
            if (attacking == true )
            {
            
                foreach (GameObject go in targets)
                {
                    if (fireOrb == true)
                    {
                      
                        go.GetComponent<TreeBossController>().hp -= 1;
                        go.GetComponent<TreeBossController>().hit = true;
                    }
                    Debug.Log("i work!!!");
                    go.GetComponent<EnemyHealth>().hp -= 1;
                    go.GetComponent<EnemyHealth>().hit = true;
                }
                onCD = true;
                cd = 0.3f;
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
            i++;
              
         
    }

}
