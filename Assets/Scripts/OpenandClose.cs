using UnityEngine;

public class OpenGameObject : MonoBehaviour
{
    // Referencia al GameObject que quieres mostrar
    public GameObject targetObject;

    // M�todo para mostrar el GameObject
    public void ShowGameObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true); // Activa el GameObject
        }
        else
        {
            Debug.LogWarning("El objeto objetivo no est� asignado en el script.");
        }
    }
}