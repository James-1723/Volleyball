using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftGround : MonoBehaviour
{
    public static bool Ball_Pos = false;
    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            GameManager.P1Score +=1;
            Ball_Pos = true;
        }
    }
}
