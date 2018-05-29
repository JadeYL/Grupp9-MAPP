using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestOne : MonoBehaviour {
    public GameObject Dialog;
    public GameObject Rocks;
    public GameObject Obstecle;
    private bool playerInArea;
    
    // Use this for initialization
    void Start () {
        playerInArea = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerInArea)
        {
            Rocks.SetActive(true);
            Obstecle.SetActive(false);
        }
	}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Dialog.SetActive(true);
        playerInArea = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Dialog.SetActive(false);
    }
}
