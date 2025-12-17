using UnityEngine;

public class Fireball : ProjectileBase
{
    [SerializeField] private float baseDamage = 10f;
    [SerializeField] private float baseSpeed = 10f;
    [SerializeField] private float cooldown = 1f;
    [SerializeField] private float lifetime = 10f;

    private float currentDamage;
    private float currentSpeed;
    private float timer = 0f;
    private Vector2 direction;

    public override float Cooldown => cooldown;
    public override float Damage => currentDamage;

    public override void Launch(Vector3 dir, float damageMultiplier, float speedMultiplier)
    {
        direction = dir.normalized;
        currentDamage = baseDamage * damageMultiplier;
        currentSpeed = baseSpeed * speedMultiplier;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = currentSpeed * direction;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > lifetime)
        {
            Debug.Log("Fireball destroyed");
            Destroy(gameObject);
        }
    }
}
