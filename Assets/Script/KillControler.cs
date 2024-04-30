using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillControler : MonoBehaviour
{
    public bool trigger = false;
    public Vector2 dir;
    Rigidbody2D rid;

    void Start()
    {
        this.trigger = false;
        this.rid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       if (this.trigger == true)
       {
           this.rid.AddForce(this.dir, ForceMode2D.Impulse);
           this.trigger = false;
       }
    }
}
