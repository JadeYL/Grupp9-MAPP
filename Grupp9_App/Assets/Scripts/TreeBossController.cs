using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBossController : MonoBehaviour {

    public GameObject root;
    public Rigidbody2D leaf;
    public GameObject shooter;
    Vector3 shooterPos;
    public int hp;
    float rootTimer;
    float leafTimer;
    float phaseTimer;
    bool vulnerable;
    bool playerInArea;
    float x, y;


    // Use this for initialization
    void Start () {
        vulnerable = false;
        playerInArea = false;
        rootTimer = 3f;
        leafTimer = 0.5f;
        x = -0.8f;
        
    }
	
	// Update is called once per frame
	void Update () {
		if (playerInArea)
        {
            //Debug.Log(time);
            phaseTimer += Time.deltaTime;
            leafTimer -= Time.deltaTime;
            rootTimer -= Time.deltaTime;
            if (rootTimer <= 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    spawnRoot();
                }
                rootTimer = 3f;
            }

            if (phaseTimer <= 15)
            {
                if (leafTimer <= 0)
                {
                    shootLeaf1();
                    leafTimer = 0.2f;
                    if (x > 0.7)
                    {
                        x = (-0.8f);
                    }
                }
            }
            else if (phaseTimer > 20 && phaseTimer <35)
            {
                if (leafTimer <= 0)
                {
                    shootLeaf2();
                    leafTimer = 2f;
                }
            
            }
            else if (phaseTimer > 35)
            {
                
                phaseTimer = 0f;
            }
        }
       // Debug.Log(phaseTimer);
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        playerInArea = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInArea = false;
    }
    private void shootLeaf1()
    {

            
            shooter.transform.localPosition = new Vector3(x, -0.1f, 0);
            Rigidbody2D leafClone = (Rigidbody2D)Instantiate(leaf, shooter.transform.position, Quaternion.identity);
            leafClone.velocity = new Vector3(0, -5, 0) * 0.5f;
            x += 0.2f;
        

    }
    private void shootLeaf2()
    {
        shooter.transform.localPosition = new Vector3(0, 0.1f, 0);
        for (int i = -16; i <16 ; i+=2)
        {
            Rigidbody2D leafClone = (Rigidbody2D)Instantiate(leaf, shooter.transform.position, Quaternion.identity);
            leafClone.velocity = new Vector3(i, -5, 0) * 0.5f;
        }
    }
    private void spawnRoot()
    {
        x = Random.Range(-0.5f,0.3f);
        y = Random.Range(-0.7f,-0.3f);
        Instantiate(root,this.transform);
        root.transform.position = new Vector3(x, y, 0);
    }
        

}
