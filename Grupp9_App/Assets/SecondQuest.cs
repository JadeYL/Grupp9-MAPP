using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondQuest : MonoBehaviour {
    public GameObject Dialog;
    public GameObject Guardian;
    private bool playerInArea = false;

	// Update is called once per frame
	void Update () {
        if (playerInArea)
        {
            Destroy(Guardian);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInArea = true;
            Dialog.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Dialog.SetActive(false);
        }
    }
}
