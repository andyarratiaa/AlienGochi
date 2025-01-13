using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameController : MonoBehaviour
{
    public GameObject button;  // Referencia al botón

    void Start()
    {
        // Aseguramos que el botón esté desactivado al inicio
        button.SetActive(false);
    }

    // Llama a este método cuando el mini-juego termine
    public void OnMiniGameEnd()
    {
        // Activamos el botón para que aparezca
        button.SetActive(true);
    }

    // Método para cargar la escena principal
    public void ReturnToMainGame()
    {
        SceneManager.LoadScene("LEVEL01");
    }
}
