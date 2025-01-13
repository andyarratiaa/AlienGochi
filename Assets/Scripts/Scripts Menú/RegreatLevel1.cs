using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegreatLevel1 : MonoBehaviour
{
    public void Retrocedecer()
    { 
        SceneManager.LoadScene("LEVEL01");
    }

    public void Home()
    {
        SceneManager.LoadScene("MENÚ");
    }
}
