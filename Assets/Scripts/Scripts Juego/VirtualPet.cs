using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VirtualPet : MonoBehaviour
{
    // UI Elements
    public Button feedButton;
    public Button cleanButton;
    public Button sleepButton;

    // GameObjects for actions
    public GameObject feedObject;
    public GameObject cleanObject;
    public GameObject sleepObject;
    public GameObject dirtObject; // Object that appears during cleaning
    public GameObject gorroObject;

    // Animator for character animations
    public Animator characterAnimator;

    // Health Bar
    public Slider healthBar;
    public float health = 100f;
    public float healthDecayRate = 0.1f; // Health decreases much slower

    public Image healthBarFill; // Reference to the fill image of the health bar

    // Action logic
    public string currentAction;
    private Coroutine actionCoroutine;
    private string lastAction;
    private string secondLastAction;

    public CambiadorDeHabitacion cambiaHabitaciones;

    void Start()
    {
        // Initialize UI and health bar
        healthBar.maxValue = health;
        healthBar.value = health;

        // Assign button listeners
        feedButton.onClick.AddListener(() => PerformAction("Feed"));
        cleanButton.onClick.AddListener(() => PerformAction("Clean"));
        sleepButton.onClick.AddListener(() => PerformAction("Sleep"));

        // Ensure all action objects are inactive at the start
        feedObject.SetActive(false);
        cleanObject.SetActive(false);
        sleepObject.SetActive(false);
        dirtObject.SetActive(false); // Ensure dirt is initially inactive

        // Start the action cycle
        actionCoroutine = StartCoroutine(ActionCycle());

        StartCoroutine(HealthDecay());
    }

    void Update()
    {
        // Reduce health over time
        if (health > 0)
        {
            // Gradual reduction, decay rate further reduced
            health -= healthDecayRate * Time.deltaTime * 0.6f; // Slow down even more
            healthBar.value = health;

            UpdateHealthBarColor();
        }
        else
        {
            GameOver();
        }
    }

    private void UpdateHealthBarColor()
    {
        // Change health bar color based on health percentage
        float healthPercentage = health / 100f;

        if (healthPercentage > 0.5f)
        {
            healthBarFill.color = Color.green; // Green when health is above 50%
        }
        else if (healthPercentage > 0.2f)
        {
            healthBarFill.color = Color.yellow; // Yellow when health is between 20% and 50%
        }
        else
        {
            healthBarFill.color = Color.red; // Red when health is below 20%
        }
    }

    private IEnumerator HealthDecay()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(20f);
            health -= healthDecayRate; // Decrease health by decay rate
            healthBar.value = health;
        }

        GameOver();
    }

    private IEnumerator ActionCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 9)); // Tiempo entre que trancurre la acci�n

            // Las acciones
            string[] actions = { "Feed", "Clean", "Sleep" };
            string newAction;

            do
            {
                int actionIndex = Random.Range(0, actions.Length);
                newAction = actions[actionIndex];
            }
            while (newAction == lastAction || newAction == secondLastAction);

            // Update action history
            secondLastAction = lastAction;
            lastAction = newAction;

            // Set the chosen action
            switch (newAction)
            {
                case "Feed":
                    SetAction("Feed", feedObject);
                    break;
                case "Clean":
                    SetAction("Clean", cleanObject);
                    dirtObject.SetActive(true); // Mostrar imagen caquita
                    break;
                case "Sleep":
                    SetAction("Sleep", sleepObject);
                    break;
            }
        }
    }

    private void SetAction(string action, GameObject actionObject)
    {
        currentAction = action;

        // Activate the corresponding GameObject
        actionObject.SetActive(true);
    }

    private void PerformAction(string action)
    {
        if (currentAction == action)
        {
            // Recompensa al jugador restaurando salud
            health = Mathf.Min(health + 7f, 100f);

            // Control de animaci�n para la acci�n de alimentar
            if (action == "Feed" && characterAnimator != null)
            {
                
                characterAnimator.SetTrigger("Eat"); // Dispara la animaci�n de comer
            }
            else if (action == "Sleep" && characterAnimator != null)
            {
                StartCoroutine(PlaySleepAnimation()); // Inicia la animaci�n de dormir prolongada
            }

            // Desactiva el GameObject correspondiente
            if (action == "Feed")
            {
                feedObject.SetActive(false);
            }
            else if (action == "Clean")
            {
                cleanObject.SetActive(false);
                dirtObject.SetActive(false); // Limpia la suciedad
            }
            else if (action == "Sleep")
            {
                sleepObject.SetActive(false);
            }

            currentAction = null; // Resetea la acci�n actual
        }
    }

    private IEnumerator PlaySleepAnimation()
    {
        if (characterAnimator != null)
        {
            characterAnimator.SetTrigger("Sleep");
            gorroObject.SetActive(false);
            yield return new WaitForSeconds(120f); // Duraci�n extendida para la animaci�n de dormir
            Debug.Log("Se pone el gorro");
            gorroObject.SetActive(true);

        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over! Your pet's health reached 0.");
        StopCoroutine(actionCoroutine);
        // Additional Game Over logic here
    }
}





