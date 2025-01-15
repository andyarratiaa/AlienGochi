using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float maxRange;
    public GameObject alien;
    public SpriteRenderer renderer;
    public float initialXPosition;
    public float x;
    void Start()
    {
        initialXPosition = -alien.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        x = alien.transform.position.x + initialXPosition;
        float entradaHorizontal = 0;

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (alien.transform.position.x + initialXPosition) > -maxRange)
        {
            entradaHorizontal = -1; 
        }
        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && (alien.transform.position.x + initialXPosition) < maxRange)
        {
            entradaHorizontal = 1; 
        }

 
        Vector3 movimiento = new Vector3(entradaHorizontal, 0, 0) * speed * Time.deltaTime;

 
        transform.Translate(movimiento);
    }
}
