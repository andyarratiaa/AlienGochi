using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public static float Score;
    public Text scoreT;
    void Start()
    {
        scoreT = GetComponent<Text>();
    }
    void Update()
    {
        scoreT.text = Score.ToString("00");
    }
}
