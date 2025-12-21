using UnityEngine;

public class Experience : MonoBehaviour
{
    [SerializeField] float baseXp = 10f;
    [SerializeField] float pickupRadius = 0.1f;
    [SerializeField] float pickupSpeed = 10f;

    GameObject magneticTarget;
    bool magnetized = false;

    public float GetExperience(float multiplier)
    {
        return baseXp * multiplier;
    }

    void Start()
    {
        magneticTarget = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (!magnetized || magneticTarget == null)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position, 
            magneticTarget.transform.position, 
            pickupSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, magneticTarget.transform.position) < pickupRadius)
        {
            if (magneticTarget.TryGetComponent(out PlayerLevel level))
            {
                level.AddXp(baseXp);
            }

            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        magnetized = true;
    }
}
