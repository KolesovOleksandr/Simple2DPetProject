using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    protected int damage = 10;

    protected float hitCooldown = 0.5f;
    protected float nextHitTime;

    void OnCollisionStay2D(Collision2D collision)
    {
        if (Time.time < nextHitTime)
        {
            return;
        }

        var health = collision.gameObject.GetComponent<PlayerHealth>();
        if (health == null)
        {
            return;
        }

        health.TakeDamage(damage);
        nextHitTime = Time.time + hitCooldown;
    }
}
