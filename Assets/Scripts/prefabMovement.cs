using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

/*public class prefabMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float rotationSpeed = 300.0f;

    public InputActionAsset inputActions;

    private InputAction move; //store the reference to the "WASD" action from your Player map
    private InputAction rotate; //store the reference to the "Rotate" action from your Player map

    private Rigidbody2D purly;

    void Awake()
    {
        purly = GetComponent<Rigidbody2D>();

        // Get actions from your Player map
        move = inputActions.FindActionMap("Player").FindAction("W");
        move = inputActions.FindActionMap("Player").FindAction("A");
        move = inputActions.FindActionMap("Player").FindAction("S");
        move = inputActions.FindActionMap("Player").FindAction("D");
        rotate = inputActions.FindActionMap("Player").FindAction("Rotate");
        // (use "Look" only if you're using it for rotation � otherwise rename it to "Rotate")
    }

    private void OnEnable()
    {
        move.Enable();
        if (rotate != null) rotate.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        if (rotate != null) rotate.Disable();
    }

    void FixedUpdate()
    {
        Vector2 input = move.ReadValue<Vector2>();

        // Movement using Rigidbody (best practice)
        purly.linearVelocity = input * speed;
    }

    void Update()
    {
        //if (rotate != null)
        //{
        //    float rotationInput = rotate.ReadValue<float>();
        //    transform.Rotate(0f, 0f, -rotationInput * rotationSpeed * Time.deltaTime);
        //}
        //pool the move action on every frame
        Vector2 moveVector = move.ReadValue<Vector2>();


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("balloonTag"))
        {
            Destroy(collision.gameObject);
        }
    }

}*/

public class prefabMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 300f;

    public InputActionAsset inputActions;

    private InputAction move;
    private InputAction rotate;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        move = inputActions.FindActionMap("Player").FindAction("Move");
        rotate = inputActions.FindActionMap("Player").FindAction("Rotate");
    }

    void OnEnable()
    {
        move.Enable();
        rotate.Enable();
    }

    void OnDisable()
    {
        move.Disable();
        rotate.Disable();
    }

    void FixedUpdate()
    {
        Vector2 input = move.ReadValue<Vector2>();
        rb.linearVelocity = input * speed;
    }

    void Update()
    {
        float rot = rotate.ReadValue<float>();
        rb.MoveRotation(rb.rotation - rot * rotationSpeed * Time.deltaTime);
    }
}