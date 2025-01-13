using UnityEngine;

public class OpenGameObject : MonoBehaviour
{
    // Referencia al GameObject que quieres mostrar u ocultar
    public GameObject targetObject;

    // Método para alternar el estado del GameObject
    public void ToggleObject()
    {
        if (targetObject != null)
        {
            // Cambia el estado activo del GameObject
            targetObject.SetActive(!targetObject.activeSelf);
        }
        else
        {
            Debug.LogWarning("El objeto objetivo no está asignado en el script.");
        }
    }
}