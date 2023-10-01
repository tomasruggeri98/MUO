using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    private RespawnManager respawnManager;

    private void Start()
    {
        currentHealth = maxHealth;
        respawnManager = FindObjectOfType<RespawnManager>(); // Encontrar el RespawnManager en la escena.
    }

    public void TakeDamage()
    {
        currentHealth --;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("weapon"))
        {
            TakeDamage();
        }
    }

    void Die()
    {
        // Notificar al RespawnManager que un enemigo ha muerto.
        respawnManager.EnemyDied();

        // Destruir este GameObject.
        Destroy(gameObject);
    }
}
