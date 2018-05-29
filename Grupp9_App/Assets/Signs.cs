using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signs : MonoBehaviour {
    public GameObject dialog;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialog.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        dialog.SetActive(false);
    }
}
