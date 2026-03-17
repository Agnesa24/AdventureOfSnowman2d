using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PurlyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float rotationSpeed = 300.0f;

    //initialize the prefab rigidbody property 
    Rigidbody2D purly;
    GameObject wall;

    void Start()
    {
        purly = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        wall = GameObject.Find("wall"); // Find the wall GameObject in the scene
    }

    void Update()
    {
        // Movement (WASD + Arrow Keys)

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            purly.MovePosition(transform.localPosition += new Vector3(0f, speed * Time.deltaTime, 0f));
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            purly.MovePosition(transform.localPosition += new Vector3(0f, -speed * Time.deltaTime, 0f));
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            purly.MovePosition(transform.localPosition += new Vector3(speed * Time.deltaTime, 0f, 0f));
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            purly.MovePosition(transform.localPosition += new Vector3(-speed * Time.deltaTime, 0f, 0f));
        }

        // Rotation (Q/E)
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Find("bottom").Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Find("bottom").Rotate(0f, -rotationSpeed * Time.deltaTime, 0f);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("balloonTag"))
        {
            Destroy(collision.gameObject);
        }
    }

}