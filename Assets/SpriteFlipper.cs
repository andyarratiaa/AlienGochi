using UnityEngine;

public class SpriteSwitcher : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Assign the SpriteRenderer in the Inspector
    public Sprite[] sprites; // Array to hold the two sprites

    private int currentSpriteIndex = 0; // Index to track the current sprite
    private float switchInterval = 0.5f; // Time interval in seconds
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchInterval)
        {
            timer = 0f; // Reset the timer
            SwitchSprite(); // Call the sprite switching function
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true; // Flip the sprite to face left
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false; // Ensure the sprite faces right
        }
    }

    private void SwitchSprite()
    {
        currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length; // Toggle between 0 and 1
        spriteRenderer.sprite = sprites[currentSpriteIndex];
    }
}

