using UnityEngine;

public class ReactivarGorro : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject gorroObject;


    public void ActivarGorro()
    {
        if (gorroObject != null)
        {
            gorroObject.SetActive(true);
            Debug.Log("Gorro activado desde el evento de animación.");
        }
    }
}
