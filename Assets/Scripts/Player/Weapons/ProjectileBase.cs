using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour, IDamageDealer
{
    protected Rigidbody2D rb;

    public virtual float Cooldown { get; }
    public virtual float Damage { get; }

    public abstract void Launch(Vector3 direction, float damageMultiplier, float speedMultiplier);

    // ToDo: Do not destroy projectile, hide it and return back to shooter (OjectPooling) !!!!
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Fireball hit: {other.name} (layer {other.gameObject.layer})");

        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(Damage);

            Destroy(gameObject);
        }
    }
}
