using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 6f;       // Speeden av Enemy
    public float stoppingDistance = 1f; //Distansen att sluta följa
    public float maxDistance = 100f;
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        //Checkar att Player är i räckvidd att bli efterföljd
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance > stoppingDistance && distance < maxDistance)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }
    }
}
