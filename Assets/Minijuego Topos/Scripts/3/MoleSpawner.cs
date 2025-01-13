using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MoleSpawner : MonoBehaviour
{
    public GameObject molePrefab;
    public Transform[] spawnPoints;
    public float gameTime;
    public Text gameText;
    public Text countdownText;
    public Button returnToMainButton; // Referencia al bot�n

    public AudioClip spawnSound; // Referencia al sonido de spawn
    private AudioSource audioSource; // Componente de AudioSource

    private bool gameStarted = false;

    void Start()
    {
        // Inicializar el bot�n como inactivo
        returnToMainButton.gameObject.SetActive(false);
        returnToMainButton.onClick.AddListener(ReturnToMainGame); // Vincular funci�n al bot�n

        // Obtener el componente AudioSource en el mismo GameObject
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(StartCountdown());
    }

    void Update()
    {
        if (gameStarted)
        {
            gameTime -= Time.deltaTime;
            if (gameTime < 0)
            {
                gameTime = 0;
                EndGame(); // Llamar a la funci�n para terminar el juego
            }
            gameText.text = Mathf.Ceil(gameTime).ToString(); // Redondea hacia arriba
        }
    }

    public void Spawn()
    {
        // Instanciar el topo en una posici�n aleatoria
        GameObject mole = Instantiate(molePrefab) as GameObject;
        mole.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;

        // Reproducir el sonido de spawn
        audioSource.PlayOneShot(spawnSound);
    }

    // Coroutine para la cuenta regresiva inicial
    IEnumerator StartCountdown()
    {
        int countdown = 3;
        while (countdown > 0)
        {
            countdownText.text = countdown.ToString(); // Mostrar el n�mero actual
            yield return new WaitForSeconds(1);       // Esperar un segundo
            countdown--;
        }

        countdownText.text = "Go!"; // Mostrar "Go!" al final
        yield return new WaitForSeconds(1);          // Esperar un segundo m�s
        countdownText.gameObject.SetActive(false);   // Ocultar el texto de cuenta regresiva

        gameStarted = true;  // Marcar que el juego ha comenzado
        Spawn();             // Iniciar el spawn
    }

    // Funci�n llamada cuando el juego termina
    void EndGame()
    {
        // Mostrar el bot�n para volver al juego principal
        returnToMainButton.gameObject.SetActive(true);
    }

    // Funci�n para regresar al juego principal
    void ReturnToMainGame()
    {
        SceneManager.LoadScene("LEVEL01"); // Cambia "NombreDeLaEscenaPrincipal" por el nombre de tu escena principal
    }
}
