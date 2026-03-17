using UnityEngine;

public class shootBullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Cannon Parameters")]
    [SerializeField] private float bulletSpeed = 8f;
    [SerializeField] private float shootInterval = 20f;

    [Header("Object References")]
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Rigidbody2D bulletPrefab;

    private Transform purly;

    void Start()
    {
        purly = GameObject.Find("purly").transform;

        InvokeRepeating(nameof(HandleShooting), 1f, shootInterval);
    }

    private void HandleShooting()
    {
        Debug.Log("Snowgun fired");
        Rigidbody2D bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity); //Spawn the bullet at bulletSpawn.position + With no rotation

                Vector2 direction = (purly.position - bulletSpawn.position).normalized;

        bullet.linearVelocity = direction * bulletSpeed;
    }
}
