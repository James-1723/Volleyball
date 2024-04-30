using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightGround : MonoBehaviour
{
    public static bool Ball_Poss = false;
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            Gamemanagerforleft.P2Score +=1;
            Ball_Poss = true;
        }
    }
}
