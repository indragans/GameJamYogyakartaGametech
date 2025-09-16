using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private float drainRate = 1f; // HP hilang tiap detik

    [SerializeField] private HealthBar healthBar;
    private float timer;
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOverUI.SetActive(true); // munculin UI
        Time.timeScale = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f) // setiap 1 detik
        {
            TakeDamage((int)drainRate);
            timer = 0f;
        }
    }

     public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        healthBar.SetValue((float)currentHealth / maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            Heal(10);
            Destroy(collision.gameObject);
        }
        /*else if (collision.CompareTag("Poison"))
        {
            TakeDamage(20);
            Destroy(collision.gameObject);
        }
        /*else if (collision.CompareTag("Energy"))
        {
            Heal(50);
            Destroy(collision.gameObject);
        }*/
    }
}
