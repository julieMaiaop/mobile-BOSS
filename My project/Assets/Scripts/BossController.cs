using UnityEngine;

public class BossController : MonoBehaviour
{
    public Health health;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 12f;
    public float fireRate = 1.2f;
    private float nextFireTime;

    public Transform playerTransform;

    public float moveDistance = 3f;
    public float moveSpeed = 2f;
    private Vector3 startPos;
    private int direction = 1;

    void Start()
    {
        startPos = transform.position;
        if (playerTransform == null)
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        MoveBoss();

        if (Time.time >= nextFireTime)
        {
            ShootAtPlayer();
            nextFireTime = Time.time + fireRate;
        }

        if (health.currentHealth <= 0)
        {
            Die();
        }
    }

    void MoveBoss()
    {
        transform.position += Vector3.right * direction * moveSpeed * Time.deltaTime;

        if (transform.position.x > startPos.x + moveDistance)
            direction = -1;
        else if (transform.position.x < startPos.x - moveDistance)
            direction = 1;
    }

    void ShootAtPlayer()
    {
        if (playerTransform == null) return;

        Vector2 directionToPlayer = (playerTransform.position - firePoint.position).normalized;
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0, 0, angle);

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.linearVelocity = directionToPlayer * bulletSpeed;
    }

    public void TakeDamage(int damage)
    {
        if (health != null)
            health.TakeDamage(damage);
    }

    void Die()
    {
        Debug.Log("Boss morreu!");
        Destroy(gameObject);
    }
}
