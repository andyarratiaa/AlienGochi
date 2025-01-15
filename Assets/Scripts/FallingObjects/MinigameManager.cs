using System.Collections;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public int XPosition;
    private int YPosition;
    public GameObject GoodItem;
    public GameObject BadItem;
    public int Points;
    public int Vidas;
    public GameObject[] HuecosVidas;
    public GameObject PanelGameOver;
    public AlienMovement alienMovement;

    private static MinigameManager singleton;
    public static MinigameManager Singleton => singleton;
    public bool playing;
    private int LifeIndex = 3;

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(WaitHalfASecond());
        PanelGameOver.SetActive(false);
    }

    void FixedUpdate()
    {
    }

    public void SpawnObjectRandomly()
    {
        Vector3 posicion = new Vector3(SetRandomCoords(), -3.2f, 0f);
        if (GoodOrBadItem())
        {
            Instantiate(GoodItem, posicion, Quaternion.identity);
        }
        else
        {
            Instantiate(BadItem, posicion, Quaternion.identity);
        }
    }

    public bool GoodOrBadItem()
    {
        int randomnumber = Random.Range(0, 10);
        return randomnumber <= 7;
    }

    public float SetRandomCoords()
    {
        return Random.Range(-1.5f, -0.9f);
    }

    public IEnumerator WaitHalfASecond()
    {
        while (playing)
        {
            SpawnObjectRandomly();
            yield return new WaitForSeconds(0.7f);
        }
    }

    public void LoseLife()
    {
        Vidas--;
        Destroy(HuecosVidas[LifeIndex - 1]);
        LifeIndex--;

        if (Vidas <= 0)
        {
            playing = false;
            PanelGameOver.SetActive(true);
            alienMovement.maxRange = -2f;
            Debug.Log("Fin del juego");
        }
    }

    public void RestartGame()
    {
        // Reset game variables
        Points = 0;
        Vidas = HuecosVidas.Length;
        LifeIndex = HuecosVidas.Length;
        playing = true;

        // Reactivate life icons
        foreach (GameObject vida in HuecosVidas)
        {
            if (vida != null)
            {
                vida.SetActive(true);
            }
        }

        // Hide the Game Over panel
        PanelGameOver.SetActive(false);

        // Destroy all spawned objects
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("GoodItem"))
        {
            Destroy(obj);
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("BadItem"))
        {
            Destroy(obj);
        }

        // Restart spawning
        StartCoroutine(WaitHalfASecond());

        Debug.Log("Juego reiniciado");
    }
}

