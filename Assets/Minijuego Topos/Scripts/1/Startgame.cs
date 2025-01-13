using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Startgame : MonoBehaviour
{
    private GameManeger GM;
    void Start()
    {
        GM = FindObjectOfType<GameManeger>();
    }
    void OnMouseDown()
    {
        GM.StartGame();
    }
}
