using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public int damage = 1;
    public string targetTag; // Configure no prefab: "Player" ou "Boss"

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            // Tenta pegar o componente correto dependendo da tag
            if (targetTag == "Player")
            {
                var player = other.GetComponent<PlayerController>();
                if (player != null)
                    player.TakeDamage(damage);
            }
            else if (targetTag == "Boss")
            {
                var boss = other.GetComponent<BossController>();
                if (boss != null)
                    boss.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Player") && !other.CompareTag("Boss") && !other.CompareTag("Bullet"))
        {
            // Destrói ao colidir com outras coisas que não são player, boss ou balas
            Destroy(gameObject);
        }
    }
}
