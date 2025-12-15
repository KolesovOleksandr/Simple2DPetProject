using UnityEngine;

public class PlayerHealth: MonoBehaviour
{
    private int maxHealth = 100;
    private int health;

    void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Player HP: {health}");

        if (health <= 0)
        {
            Debug.Log("Player died!");
            
            gameObject.SetActive(false);
        }
    }
}
