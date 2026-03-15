using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PurlyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float rotationSpeed = 300.0f;
    Camera cam; // Reference to the main camera

    //initialize the prefab rigidbody property 
    Rigidbody2D purly;
    GameObject wall; 

    void Start()
    {
        cam = Camera.main; // Get the main camera
        purly = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        wall = GameObject.Find("wall"); // Find the wall GameObject in the scene
    }

    void Update()
    {
        // Movement (WASD + Arrow Keys)
        /*Vector2 move = Vector2.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            move += Vector2.up;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            move += Vector2.down;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            move += Vector2.right;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            move += Vector2.left;

        purly.linearVelocity = move.normalized * speed;*/

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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject == wall)
            {
                purly.linearVelocity = -purly.linearVelocity;
            }
        }
}