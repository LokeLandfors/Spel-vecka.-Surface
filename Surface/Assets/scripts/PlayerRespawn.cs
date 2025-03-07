using Cinemachine;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint; //Stället där Player ska respawna
    public int playerHealth = 10; // Player's health
    [SerializeField] CinemachineVirtualCamera cam;

    void Update()
    {
        if (playerHealth <= 0)
        {
            Respawn();
        }
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        Debug.Log("Player Health: " + playerHealth);

        if (playerHealth <= 0)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // skicka Player till respawnPointen
        transform.position = respawnPoint.position;

        // Resettar health
        playerHealth = 10;
        cam.Follow = gameObject.transform;
        Debug.Log("Player respawned!");
    }
}
