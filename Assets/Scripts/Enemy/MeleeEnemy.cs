using UnityEngine;

public class MeleeEnemy : Enemy, IDamageDealer
{
    [SerializeField]private float damage = 10f;
    public float Damage => damage;

    protected override void Chase()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        transform.position = transform.position + speed * Time.deltaTime * dir;
    }
     
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            if (nextHitTime > Time.time)
            {
                return;
            }

            playerHealth.TakeDamage(damage);
            nextHitTime = Time.time + cooldown;
        }
    }
}
