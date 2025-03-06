using UnityEngine;
using System.Collections;


public class Elevator : MonoBehaviour
{
    public float speed = 2f; // hastighet
    public float distance = 5f; // hur långt
    private Vector3 startPosition;
    private bool isMoving = false;
    private bool playerNearby = false;
    public Animation anim;

    void Start()
    {
       // startPosition = transform.position;
    }

    void Update()
    {
        if (playerNearby && Input.GetKey(KeyCode.E) && !isMoving)
        {
            MoveElevator();
        }
    }

    private void MoveElevator()
    {
        //isMoving = true;
        //Vector3 targetPosition = startPosition + Vector3.down * distance;
        //while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        //{
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        //}
        //isMoving = false;
        anim.Play("Elevator");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        print("Rörd");
        if (other.collider.CompareTag("Player"))
        {
            playerNearby = true;
            other.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            playerNearby = false;
            other.transform.SetParent(null);
        }
    }
}