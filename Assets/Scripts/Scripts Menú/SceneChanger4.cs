using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para gestionar escenas

public class SceneChanger4 : MonoBehaviour
{
    // M�todo para cambiar de escena por nombre
    public void ChangeSceneByName(string sceneName)
    {
        SceneManager.LoadScene("FallingObjects");
    }

    // M�todo para cambiar de escena por �ndice
    public void ChangeSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // Opcional: M�todo para salir del juego
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("El juego se ha cerrado."); // Esto no funciona en el editor
    }
}
