using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float speed = 6f;
    [SerializeField] private float bulletLifetime = 10f;

    private Transform purly;

    void Start()
    {
        purly = GameObject.Find("purly").transform;

        Destroy(gameObject, bulletLifetime);
    }

    void Update()
    {
        if (purly == null) return;

        Vector2 direction = (purly.position - transform.position).normalized;

        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "purly")
        {
            Destroy(collision.gameObject);
        }
    }
}
