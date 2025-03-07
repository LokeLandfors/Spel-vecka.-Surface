using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletGo : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damage;
    public int penetrationDepth; //hur många fiender kan träffas
    public string killTag;
    void Start()
    {
        // Förstör bulleten efter en sett amount of tid
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Skjut bulleten fram
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Applya damage när bulleten träffar en enemy med Health komponent
        if (collision.gameObject.CompareTag(killTag))
        {
            if (collision.GetComponent<Health>())
            {
                Health target = collision.GetComponent<Health>();
                target.TakeDamage(damage);
            }
            else
            {
                collision.GetComponent<PlayerRespawn>().TakeDamage(damage);
            }
            if (penetrationDepth > 0)
            {
                Destroy(gameObject);
            }
        }
        else if (!(collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "DamageZone"))
        {
            Destroy(gameObject);
        }
    }
}