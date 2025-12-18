using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed = 3f;
    [SerializeField] protected float cooldown = 2f;
    [SerializeField] protected float health, maxHealth = 100f;
    protected float nextHitTime;

    protected Transform target;

    protected virtual void Start()
    {
        target = GameObject.Find("Player").transform;
        health = maxHealth;
    }

    protected virtual void Update()
    {
        if (target == null)
        {
            return;
        }

        Chase();
        OnUpdate();
    }

    protected abstract void Chase();

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"Enemy HP: {health}");

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);

    }

    protected virtual void OnUpdate() { }
}
