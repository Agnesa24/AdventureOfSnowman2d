using UnityEngine;

public class prefabMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //2 values to control the speed and rotation of the football
    [SerializeField] 
    private float speed = 2.0f; //speed of the snowman
    [SerializeField] 
    private float rotationSpeed = 10.0f; //rotation speed of the snowman
    void Start()
    {
        //nothing to put here 
    }

    // Update is called once per frame

    void Update()
    {
        // ----- ROTATION -----

        // Turn left
        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }

        // Turn right
        if (Input.GetKey(KeyCode.F))
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }


        // ----- MOVEMENT -----

        // Move up
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }

        // Move down
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }

        // Move right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        // Move left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
    }

}
