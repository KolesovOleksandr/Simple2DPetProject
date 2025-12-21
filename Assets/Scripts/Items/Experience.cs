using UnityEngine;

public class Experience : MonoBehaviour
{
    [SerializeField] float baseExp = 20f;
    [SerializeField] float pickupRadius = 0.1f;
    [SerializeField] float pickupSpeed = 10f;

    GameObject magneticTarget;
    bool magnetized = false;

    public float GetExperience(float multiplier)
    {
        return baseExp * multiplier;
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
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        magnetized = true;
    }
}
