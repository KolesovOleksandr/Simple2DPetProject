using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;

    [SerializeField] private float health;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"Player HP: {health}");

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
