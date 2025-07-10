using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint;

    void Update()
    {
        // PC: tecla Z
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Shoot();
        }
    }

    // Botão mobile chama esse método
    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
