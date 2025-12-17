using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField] private float preferedDistance = 10f;

    protected override void Chase()
    {
        float distance = Vector2.Distance(transform.position, target.position);

        if (distance > preferedDistance)
        {
            Vector3 dir = (target.position - transform.position).normalized;
            transform.position += speed * Time.deltaTime * dir;
        }
    }
}
