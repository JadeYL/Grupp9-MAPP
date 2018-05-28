using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBossController : MonoBehaviour {

    public GameObject root;
    public Rigidbody2D leaf;
    public Rigidbody2D leaf2;
    public GameObject shooter;
    Vector3 shooterPos;
    public int hp;
    float rootTimer;
    float leafTimer;
    float phaseTimer;
    bool vulnerable;
    public bool playerInArea;
    float x, y;


    // Use this for initialization
    void Start () {
        vulnerable = false;
        playerInArea = false;
        rootTimer = 3f;
        leafTimer = 0.5f;
        phaseTimer = 0;
        x = -2.4f;
        
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
                    if (x >= 2.4)
                    {
                        x = (-2.4f);
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
            else if (phaseTimer > 39)
            {
                
                phaseTimer = 0f;
            }
        }

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
            Rigidbody2D leafClone = (Rigidbody2D)Instantiate(RandomLeaf(), shooter.transform.position, Quaternion.identity);
            leafClone.velocity = new Vector3(0, -5, 0) * 0.5f;
            x += 0.6f;
        

    }
    private void shootLeaf2()
    {
        shooter.transform.localPosition = new Vector3(0, 0.1f, 0);
        for (int i = -16; i <16 ; i+=2)
        {
            Rigidbody2D leafClone = (Rigidbody2D)Instantiate(RandomLeaf(), shooter.transform.position, Quaternion.identity);
            leafClone.velocity = new Vector3(i, -5, 0) * 0.5f;
        }
    }
    private void spawnRoot()
    {
        x = Random.Range(-2.4f,1.8f);
        y = Random.Range(-1.3f,-2.5f);
        Instantiate(root,this.transform);
        root.transform.position = new Vector3(x, y, 0);
    }
    Rigidbody2D RandomLeaf()
    {
        int rnd = Random.Range(0,3);
        switch (rnd)
        {
            case 1:
                return leaf;
            case 2:
                return leaf2;
            default:
                return leaf;
        }
    }
        

}
