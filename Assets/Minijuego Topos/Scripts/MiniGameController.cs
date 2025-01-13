using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameController : MonoBehaviour
{
    public GameObject button;  // Referencia al bot�n

    void Start()
    {
        // Aseguramos que el bot�n est� desactivado al inicio
        button.SetActive(false);
    }

    // Llama a este m�todo cuando el mini-juego termine
    public void OnMiniGameEnd()
    {
        // Activamos el bot�n para que aparezca
        button.SetActive(true);
    }

    // M�todo para cargar la escena principal
    public void ReturnToMainGame()
    {
        SceneManager.LoadScene("LEVEL01");
    }
}
