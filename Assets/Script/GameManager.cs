using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int P1Score = 0;
    public GameObject targetUI;
    public Text targetText;
    public static bool Over;
    void Update()
    {
        GetScore1();
    }
    public void GetScore1 ()
    {
        targetText.text = P1Score.ToString();
        if (P1Score >=5)
        {
            targetUI.SetActive(true);
            Over = true;
        }
    }
}
