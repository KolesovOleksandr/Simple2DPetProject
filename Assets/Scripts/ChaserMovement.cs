using UnityEngine;

public class ChaserMovement : MonoBehaviour
{
    private Transform player;
    public float speed = 3f;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += (direction * speed * Time.deltaTime);
    }
}
