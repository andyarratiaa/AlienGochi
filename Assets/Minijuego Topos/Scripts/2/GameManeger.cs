using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManeger : MonoBehaviour
{
    public int MoleNumber;
    public float count = 2f;
    public GameObject Moles;
    public float Roundtime = 30;
    public GameObject Nice, startbutton;
    public bool runtimers = false;
    public void SetMole()
    {
        MoleNumber = Random.Range(1, 7);
        if (MoleNumber == 1)
        {
            Instantiate(Moles, new Vector3(-4, -4.44f, 0), Quaternion.identity);
        }
        if (MoleNumber == 2)
        {
            Instantiate(Moles, new Vector3(0, -4.44f, 0), Quaternion.identity);
        }
        if (MoleNumber == 3)
        {
            Instantiate(Moles, new Vector3(4.2f, -4.44f, 0), Quaternion.identity);
        }
        if (MoleNumber == 4)
        {
            Instantiate(Moles, new Vector3(4.27f, -1.1f, 0), Quaternion.identity);
        }
        if (MoleNumber == 5)
        {
            Instantiate(Moles, new Vector3(0f, -1.1f, 0), Quaternion.identity);
        }
        if (MoleNumber == 6)
        {
            Instantiate(Moles, new Vector3(-3.8f, -1.1f, 0), Quaternion.identity);
        }
    }

    void Start()
    {
        Nice.SetActive(false);
    }

    public void StartGame()
    {
        startbutton.SetActive(false);
        Nice.SetActive(false);
        Scoring.Score = 0;
        Roundtime = 30;
        count = 2f;
        runtimers = true;
    }

    void Update()
    {
        if (runtimers == true)
        {
            Roundtime -= Time.deltaTime;
            if (Roundtime <= 0)
            {
                Nice.SetActive(true);
                startbutton.SetActive(true);
                Roundtime = 0;
                count = 2f;
            }
            if (Roundtime > 0)
            {
                count -= Time.deltaTime;
            }
            if (count <= 0)
            {
                {
                    SetMole();
                    count = 2f;
                }
            }
        }
    }
}
