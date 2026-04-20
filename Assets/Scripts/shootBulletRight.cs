using UnityEngine;

public class shootBulletRight : MonoBehaviour
{
    //this class is for the right cannon that will shoot after a delay of 20 seconds so after the left cannon 

    [Header("Cannon Parameters")]
    [SerializeField] private float bulletSpeed = 6.5f;
    [SerializeField] private float shootInterval = 20f;

    [Header("Object References")]
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Rigidbody2D BulletPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(HandleShooting), 10f, shootInterval); //unity will call the method HandleShooting starting after 10 second and then every shootInterval 
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void HandleShooting()
    {

        Debug.Log("Snowgun fired");

        Rigidbody2D bullet = Instantiate(BulletPrefab, bulletSpawn.position, Quaternion.identity); //creates the spawn position of the bullet prefab 

        // RANDOM direction (not toward Purly anymore)
        //Vector2 direction = Vector2.left; //will shoot the bullet to the left, which is the direction of the right cannon
        //bullet.linearVelocity = direction * bulletSpeed;// applies the movement to the bullet

        Vector2 randomPosition = new Vector2(
            Random.Range(-7.77f, 7.67f),
            Random.Range(-4.13f, -4.13f)
        );
        bullet.linearVelocity = randomPosition * bulletSpeed;

    }
}
