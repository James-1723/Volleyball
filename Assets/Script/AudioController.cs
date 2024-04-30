using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public GameObject soundObject;
    public GameObject BGM_Source1;
    public GameObject BGM_Source2;

    void Start()
    {
        
    }

    void Update() 
    {
        if (P2Movement.Sound == true)
        {
            Instantiate(soundObject);
            P2Movement.Sound = false;
        }
    }
}
