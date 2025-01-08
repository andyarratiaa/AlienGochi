using UnityEngine;

public class OpenGameObject : MonoBehaviour
{
    // Referencia al GameObject que quieres mostrar
    public GameObject targetObject;

    // Método para mostrar el GameObject
    public void ShowGameObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true); // Activa el GameObject
        }
        else
        {
            Debug.LogWarning("El objeto objetivo no está asignado en el script.");
        }
    }
}