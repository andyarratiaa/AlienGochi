using UnityEngine;

public class SpriteSwitcher2 : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Assign the SpriteRenderer in the Inspector
    public Sprite[] sprites; 
    public float switchInterval = 0.5f; 

    private int currentSpriteIndex = 0; // Index to track the current sprite
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchInterval)
        {
            timer = 0f; // Reset the timer
            SwitchSprite(); // Call the sprite switching function
        }
    }

    private void SwitchSprite()
    {
        currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length; // Toggle between sprites
        spriteRenderer.sprite = sprites[currentSpriteIndex];
    }
}
