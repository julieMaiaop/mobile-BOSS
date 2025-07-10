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

    // Bot�o mobile chama esse m�todo
    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
