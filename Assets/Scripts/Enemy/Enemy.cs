using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed = 3f;
    [SerializeField] protected float cooldown = 2f;
    protected Transform target;

    protected float nextHitTime;

    protected virtual void Start()
    {
        
        target = GameObject.Find("Player").transform;
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

    protected virtual void OnUpdate() { }
}
