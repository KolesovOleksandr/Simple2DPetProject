using UnityEngine;

public class EnemyProjectile : MonoBehaviour, IDamageDealer
{
    [SerializeField] private float speed = 30f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float lifetime = 10f;
    private Transform target;

    private float timer = 0f;
    private Rigidbody2D rb;

    public float Damage => damage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;
        Vector3 direction = (target.position - transform.position).normalized;

        rb.linearVelocity = speed * direction;
    }

    // ToDo: Do not destroy projectile, hide it and return back to enemy (OjectPooling) !!!!
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > lifetime)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(Damage);

            Destroy(gameObject);
        }
    }
}
