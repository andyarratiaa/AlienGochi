using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoleSpawner : MonoBehaviour
{
    public GameObject molePrefab;
    public Transform[] spawnPoints;
    public float gameTime;
    public Text gameText;
    public Text countdownText;

    private bool gameStarted = false;

    void Start()
    {
        StartCoroutine(StartCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            gameTime -= Time.deltaTime;
            if (gameTime < 0)
            {
                gameTime = 0;
            }
            gameText.text = Mathf.Ceil(gameTime).ToString(); // Redondea hacia arriba
        }
    }
    public void Spawn()
    {
        GameObject mole = Instantiate(molePrefab) as GameObject;
        mole.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
    }

    // Coroutine para la cuenta regresiva inicial
    IEnumerator StartCountdown()
    {
        int countdown = 3;
        while (countdown > 0)
        {
            countdownText.text = countdown.ToString(); // Mostrar el número actual
            yield return new WaitForSeconds(1);       // Esperar un segundo
            countdown--;
        }

        countdownText.text = "Go!"; // Mostrar "Go!" al final
        yield return new WaitForSeconds(1);          // Esperar un segundo más
        countdownText.gameObject.SetActive(false);   // Ocultar el texto de cuenta regresiva

        gameStarted = true;  // Marcar que el juego ha comenzado
        Spawn();             // Iniciar el spawn
    }
}