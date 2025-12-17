    using UnityEngine;

    public class RangedEnemy : Enemy
    {
        [SerializeField] private float preferedDistance = 10f;

        public GameObject projectile;

        protected override void Chase()
        {
            float distance = Vector2.Distance(transform.position, target.position);

            if (distance > preferedDistance)
            {
                Vector3 dir = (target.position - transform.position).normalized;
                transform.position += speed * Time.deltaTime * dir;
            }
        }

        protected override void OnUpdate()
        {
            if (nextHitTime > Time.time)
            {
                return;
            }

            float distance = Vector2.Distance(transform.position, target.position);
            if ( distance <= preferedDistance)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
            }

            nextHitTime = Time.time + cooldown;
        }
    }
