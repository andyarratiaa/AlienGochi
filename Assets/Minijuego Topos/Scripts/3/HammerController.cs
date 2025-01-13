using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HammerController : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public AudioClip hitSound; // Referencia al sonido de golpe
    private AudioSource audioSource; // Componente AudioSource

    private MoleSpawner ms;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        ms = GetComponent<MoleSpawner>();
        audioSource = GetComponent<AudioSource>(); // Obtener el AudioSource

        // Verificar si el AudioSource no est� asignado
        if (audioSource == null)
        {
            Debug.LogError("No se encontr� un AudioSource en el GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && ms.gameTime > 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                Destroy(hit.transform.gameObject);
                score += 1;
                scoreText.text = score.ToString();
                ms.Spawn();

                // Reproducir el sonido de golpe si el AudioSource y el AudioClip est�n configurados
                if (audioSource != null && hitSound != null)
                {
                    audioSource.PlayOneShot(hitSound); // Reproducir el sonido de golpe
                }
                else
                {
                    Debug.LogWarning("No se pudo reproducir el sonido de golpe. Aseg�rate de que el AudioSource y el AudioClip est�n configurados correctamente.");
                }
            }
        }
    }

    public void ResetGame()
    { 
        //score = 0;
        SceneManager.LoadScene("Topo Sencillo");
    }
}
