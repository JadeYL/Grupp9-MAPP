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
    bool vulnerable;
    bool playerInArea;
    float x, y;


    // Use this for initialization
    void Start () {
        vulnerable = false;
        playerInArea = false;
        rootTimer = 3f;
        leafTimer = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerInArea)
        {
            //Debug.Log(time);
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
            if(leafTimer<=0)
            {
                shootLeaf();
                leafTimer = 0.5f;
            }
        }
        Debug.Log(playerInArea);
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        playerInArea = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInArea = false;
    }
    private void shootLeaf()
    {
            
            x += 0.1f;
            shooter.transform.localPosition = new Vector3(x, -0.1f, 0);
            Rigidbody2D leafClone = (Rigidbody2D)Instantiate(leaf, shooter.transform.position, Quaternion.identity,shooter.transform);
            leafClone.velocity = new Vector3(0, -5, 0) * 2f;
            
        

    }
    private void spawnRoot()
    {
        x = Random.Range(-0.5f,0.3f);
        y = Random.Range(-0.7f,-0.3f);
        Instantiate(root,this.transform);
        root.transform.position = new Vector3(x, y, 0);
    }

}
