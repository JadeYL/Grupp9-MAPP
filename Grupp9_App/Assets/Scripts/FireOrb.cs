using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOrb : MonoBehaviour {
    public bool taken = false;
    public void Start()
    {
        taken = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            taken = true;
            Destroy(this.gameObject);
        }
    }
}
