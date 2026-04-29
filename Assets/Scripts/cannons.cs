using UnityEngine;

public class cannons : MonoBehaviour
{
    [Header("Cannon Parameters")]
    [SerializeField] private float bulletSpeed = 6.5f;

    [Header("Object References")]
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Rigidbody2D BulletPrefab;

    private float timer;
    private float nextShootTime;

    static cannons lastCannon; // static reference to prevent same cannon twice in a row

    void Start()
    {
        SetNextShootTime();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= nextShootTime)
        {
            Shoot();
            SetNextShootTime();
        }
    }

    void Shoot()
    {
        // prevent same cannon twice in a row
        if (lastCannon == this)
            return;

        Debug.Log("Snowgun fired");

        Rigidbody2D bullet = Instantiate(BulletPrefab, bulletSpawn.position, Quaternion.identity);

        // random direction (right cannon = shoots left)
        Vector2 target = new Vector2(
            Random.Range(-18f, 17f), 
            Random.Range(-3.86f, 2.65f)
        );

        // direction from cannon to target
        Vector2 direction = (target - (Vector2)bulletSpawn.position).normalized;

        bullet.linearVelocity = direction * bulletSpeed;
        bullet.linearVelocity = direction * bulletSpeed;

        lastCannon = this;
    }

    void SetNextShootTime()
    {
        timer = 0f;
        nextShootTime = Random.Range(5f, 20f); // random delay
    }
}
