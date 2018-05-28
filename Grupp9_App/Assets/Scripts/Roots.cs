using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots : MonoBehaviour {
    GameObject root;
    float time;
    // Use this for initialization
    void Start () {
        root = transform.GetChild(0).gameObject;
        time = 0;
    }
	
	// Update is called once per frame
	void Update () {
       
       time += Time.deltaTime;
        if (time > 1f)
        {
            root.SetActive(true);
        }

	}
}
