﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOverTime : MonoBehaviour
{
    public float time = 5;
    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject,time);
    }
}
