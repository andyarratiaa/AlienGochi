using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    public float speed = 2.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float entradaHorizontal = 0;

        if (Input.GetKey(KeyCode.A))
        {
            entradaHorizontal = -1; 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            entradaHorizontal = 1; 
        }

 
        Vector3 movimiento = new Vector3(entradaHorizontal, 0, 0) * speed * Time.deltaTime;

 
        transform.Translate(movimiento);
    }
}
