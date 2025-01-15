using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float maxRange;
    public GameObject alien;
    public SpriteRenderer renderer;
    public float initialXPosition;
    public float x;
    public bool isFacingRight;
    public GameObject pivotController;
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
            isFacingRight = false;
        }
        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && (alien.transform.position.x + initialXPosition) < maxRange)
        {
            entradaHorizontal = 1;
            isFacingRight = true;
        }

        FlipSprite(isFacingRight);
        Vector3 movimiento = new Vector3(entradaHorizontal, 0, 0) * speed * Time.deltaTime;

 
        transform.Translate(movimiento);
    }

    public void FlipSprite(bool isFacingRight)
    {

        renderer.flipX = !isFacingRight;
    }
}
