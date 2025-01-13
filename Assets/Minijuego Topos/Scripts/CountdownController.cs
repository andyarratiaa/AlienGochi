using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownController : MonoBehaviour
{
    public int countdownTime = 3; // Tiempo inicial de cuenta regresiva
    public Text countdownDisplay; // UI para mostrar el contador

    // Referencia al GameManager para llamar a StartGame cuando termine la cuenta regresiva
    public GameManeger gameManager;

    private void Start()
    {
        // Asegúrate de que el GameManager esté asignado
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManeger>();
        }

        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString(); // Muestra el tiempo
            yield return new WaitForSeconds(1f); // Espera 1 segundo
            countdownTime--; // Decrementa el tiempo
        }

        countdownDisplay.text = "GO!"; // Cuando termine la cuenta regresiva, muestra "GO!"
        yield return new WaitForSeconds(1f); // Espera 1 segundo

        // Comienza el juego
        gameManager.StartGame();

        // Desactiva la pantalla del contador
        countdownDisplay.gameObject.SetActive(false);
    }
}
