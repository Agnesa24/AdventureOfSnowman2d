using UnityEngine;

public class shootBulletLeft : MonoBehaviour
{
    //this is for the left cannon that will shoot right at the beginning and then every 20 seconds 


    //public shootBullet gun1;

    [Header("Cannon Parameters")]
    [SerializeField] private float bulletSpeed = 6.5f;
    [SerializeField] private float shootInterval = 20f;

    [Header("Object References")]
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Rigidbody2D BulletPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(HandleShooting), 0f, shootInterval); //unity will call the method HandleShooting starting after 1 second and then every shootInterval 

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
        //Vector2 direction = Vector2.right; //will shoot the bullet to the right, which is the direction of the left cannon
        //bullet.linearVelocity = direction * bulletSpeed;// applies the movement to the bullet

        Vector2 direction = new Vector2(1f, 0.3f); // right + slight up
        bullet.linearVelocity = direction * bulletSpeed;
    }
}
