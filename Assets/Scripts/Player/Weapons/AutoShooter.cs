using UnityEngine;

public class AutoShooter : MonoBehaviour
{
    [SerializeField] float globalAttackSpeedMultiplier = 1f;
    [SerializeField] float globalSpeedMultiplier = 1f;
    [SerializeField] float globalDamageMultiplier = 1f;

    [SerializeField] private float radius = 50f;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private int bufferSize = 64;

    private ContactFilter2D filter;

    [Header("Weapons")]
    public WeaponSlot[] weapons;
    private Collider2D[] buffer;

    void Awake()
    {
        buffer = new Collider2D[bufferSize];
        filter = new()
        {
            useLayerMask = true,
            layerMask = enemyMask,
            useDepth = false,
            useTriggers = true
        };
    }

    void Update()
    {
        Transform closest = FindClosest();
        if (closest == null)
        {
            return;
        }

        var dir = (closest.position - transform.position).normalized;

        for (int i  = 0; i < weapons.Length; i++)
        {
            TryShoot(weapons[i], dir);
        }
    }

    private void TryShoot(WeaponSlot w, Vector2 dir)
    {
        if (w == null || w.nextFireTime > Time.time)
        {
            return;
        }

        var proj = Instantiate(w.projectile, transform.position, Quaternion.identity);
        proj.Launch(dir, globalDamageMultiplier, globalSpeedMultiplier);

        w.nextFireTime = Time.time + w.projectile.Cooldown / globalAttackSpeedMultiplier;
    }

    private Transform FindClosest()
    {
        int count = Physics2D.OverlapCircle((Vector2)transform.position, radius, filter, buffer);

        Transform closest = null;
        float bestSqr = float.MaxValue;
        Vector3 pos = transform.position;

        for (int i = 0; i < count; i++)
        {
            var col = buffer[i];
            if (col == null) continue;

            var enemy = col.GetComponentInParent<Enemy>();
            if (enemy == null) continue;
            Transform t = enemy.transform;

            float sqr = (t.position - pos).sqrMagnitude;
            if (sqr < bestSqr)
            {
                bestSqr = sqr;
                closest = t;
            }
        }

        return closest;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}