using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tem : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Left Ground"))
        {
            Debug.Log(22);
        }
    }

}
