using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerAttack : MonoBehaviour {
    public float damage;
    bool attacking;
    public float cd;
    bool onCD;
    List<GameObject> targets = new List<GameObject>();

    // Use this for initialization
    void Awake()
    {
        onCD = false;
        cd = 0.3f;
    }

    // Update is called once per frame
    void Update() {

        
        if (cd > 0)
        {
            onCD = true;
            attacking = false;
            cd -= Time.deltaTime;
           
        }
        else if (cd <= 0)
        {
            GetComponentInParent<PlayerMovment>().moveSpeed = 0.05f;
            onCD = false;
            if (Input.GetKeyDown("e"))
            {
                attack();
                
            }
            if (attacking == true )
            {
                foreach (GameObject go in targets)
                {
                go.GetComponent<EnemyHealth>().hp -= 1;
                go.GetComponent<EnemyHealth>().hit = true;

                }
                attacking = false;
                Debug.Log(attacking);
                onCD = true;
                cd = 0.3f;
            }
            else
            {
                if (GetComponentInParent<PlayerMovment>().terrainhit == false)
                {
                    
                }
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
        GetComponentInParent<PlayerMovment>().moveSpeed = 0.01f;
        attacking = true;
            
    }

}
