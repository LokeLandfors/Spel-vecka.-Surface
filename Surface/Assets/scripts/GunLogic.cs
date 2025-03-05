using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogic : MonoBehaviour
{
    public string fireKey; // the key to fire

    [SerializeField] GameObject firePoint; // Where the bullet comes out of


    public float fireRate; // The speed of firerate (X RPM)
    public float bulletSpeed; // Speed for next bullet.
    public float spread; // The rough area of bullet spread
    public int bulletsFired; // The amount of bullets fired at once
    private float fireTime = 0; // Cooldown for the next shot

    public GameObject bulletObj; // The bullet itself. (What the gun shoots out)
    private void CreateBullet(GameObject Bullet)
    {
        GameObject bullet = Instantiate(Bullet); // Clones the bullet so it can be fired multiple times
        bullet.gameObject.transform.rotation = firePoint.transform.rotation;
        bullet.gameObject.transform.position = firePoint.transform.position;
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed + (gameObject.transform.right * Random.Range(-spread, spread));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fireTime <= 0 && Input.GetButton(fireKey))
        {
            CreateBullet(bulletObj); // Spawns bullet
            fireTime = fireRate; // Resets frames
        }
        else // Activates if...  
        {
            fireTime -= Time.fixedDeltaTime;
        }
    }
}