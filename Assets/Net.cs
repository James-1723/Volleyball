﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 upforce;
    public Rigidbody2D rigid;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            rigid.AddForce(upforce, ForceMode2D.Impulse);
        }
    }
}
