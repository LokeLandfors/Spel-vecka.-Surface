using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem testParticleSystem = default;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * 15 * Time.deltaTime; //bullet code
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall") // If collision is a wall, destroy itself and play an effect (Can be used for killing zombbiieiss)
        {
            Instantiate(testParticleSystem, transform.position, Quaternion.identity).Play();
            Destroy(gameObject, 0.005F);
            //testParticleSystem.Play();
        }
    }
}
