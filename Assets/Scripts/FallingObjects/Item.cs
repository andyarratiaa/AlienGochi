using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool GoodItem;
    public float speed = 1.0f;
    public int GoodItemPoints = 10;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y <= -4.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GoodItem)
        {
            MinigameManager.Singleton.Points += GoodItemPoints;
        }
        else
        {
            MinigameManager.Singleton.LoseLife();
        }

        Destroy(gameObject);
    }

    public void DestroyOnEnd()
    {
        
    }
}
