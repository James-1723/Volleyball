using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanagerforleft : MonoBehaviour
{
    public static int P2Score = 0;
    public GameObject targetUI;
    public GameObject instantiative_view;
    public Text targetText;

    void Update()
    {
        GetScore();
        if (Input.GetKey(KeyCode.B))
        {
            instantiative_view.SetActive(false);
        }
    }
    public void GetScore ()
    {
        targetText.text = P2Score.ToString();
        if (P2Score >=5)
        {
            targetUI.SetActive(true);
        }
    }
}
