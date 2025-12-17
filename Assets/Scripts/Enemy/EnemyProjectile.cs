using UnityEngine;

public class EnemyProjectile : MonoBehaviour, IDamageDealer
{
    [SerializeField] private float speed = 30f;
    [SerializeField] private float damage = 10f;
    private Transform target;

    private float timer = 0f;
    private Vector3 direction;

    public float Damage => damage;

    void Start()
    {
        target = GameObject.Find("Player").transform;
        direction = (target.position - transform.position).normalized;
    }

    void Update()
    {
        timer += Time.deltaTime;

        transform.position = transform.position + speed * Time.deltaTime * direction;

        if (timer > 10f)
        {
            Destroy(gameObject);
            timer = 0f;
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
