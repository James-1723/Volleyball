using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    public Vector2 Dir2 = new Vector2(1,0);
    public Vector2 Dir1 = new Vector2(-1,0);

    public Rigidbody2D rig;

    public float power;
    public Vector2 toleft;
    public Vector2 toright;
    void Start()
    {
        this.rig = GetComponent<Rigidbody2D>();

    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.KeypadEnter))
            {
                rig.AddForce(toright, ForceMode2D.Impulse);
            }

            if(Input.GetKey(KeyCode.V))
            {
                rig.AddForce(toleft, ForceMode2D.Impulse);
            }
        }
    }
}