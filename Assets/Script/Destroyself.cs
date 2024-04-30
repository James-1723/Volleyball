using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyself : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BGM1.BGB == true)
        {
            Destroy(gameObject, 1.0f);
        }
    }
}
