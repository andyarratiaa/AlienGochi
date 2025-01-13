using UnityEngine;

public class OpenGameObject : MonoBehaviour
{
    // Referencia al GameObject que quieres mostrar u ocultar
    public GameObject targetObject;

    // M�todo para alternar el estado del GameObject
    public void ToggleObject()
    {
        if (targetObject != null)
        {
            // Cambia el estado activo del GameObject
            targetObject.SetActive(!targetObject.activeSelf);
        }
        else
        {
            Debug.LogWarning("El objeto objetivo no est� asignado en el script.");
        }
    }
}