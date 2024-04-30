using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM1 : MonoBehaviour
{
    public GameObject BGM_1;
    public GameObject target;
    public static bool BGB;
    void Start()
    {
        Instantiate(BGM_1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.N))
        {
            Destroy(gameObject);
            BGB = true;
            target.SetActive(true);
        }
    }
}
