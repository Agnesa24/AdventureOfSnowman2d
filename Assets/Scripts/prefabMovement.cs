using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
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
/*  // This is the code for the new input system
public class prefabMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 300f;
    [SerializeField] private Animator animator;

    public InputActionAsset inputActions;

    private InputAction move;
    private InputAction rotate;

    private Rigidbody2D rb;


    this following code is when you want to use the new input system

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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene("MenuScene");
        }
    }
}*/

public class prefabMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    private float moveX;
    public float MoveSpeed = 5f;

    public LayerMask groundLayer;
    private bool isGrounded;

    /*for the splash effect*/
    [SerializeField] private Transform groundCheck;
    [SerializeField] private GameObject splashEffect;


    /*for the sounds*/
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip splashSound;
    [SerializeField] private AudioClip yellowBalloonSound;
    [SerializeField] private AudioClip blackBalloonSound;

    private float splashTimer;
    public float splashDelay = 0.3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Exit game to menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuScene");
        }

        // Movement input
        moveX = Input.GetAxisRaw("Horizontal");

        // Ground check
        isGrounded = Physics2D.Raycast(
            transform.position,
            Vector2.down,
            0.5f,
            groundLayer
        );

        // Send values to Animator
        animator.SetBool("isGrounded", isGrounded);
        //animator.SetFloat("moveX", moveX);

        // Optional directional booleans (only if you still use them in Animator)
        animator.SetBool("isWalkingLeft", moveX < 0);
        animator.SetBool("isWalkingRight", moveX > 0);


        if (moveX != 0 && isGrounded)
        {
            splashTimer += Time.deltaTime;

            if (splashTimer >= splashDelay)
            {
                SpawnSplash();
                splashTimer = 0f;
            }
        }
        else
        {
            splashTimer = splashDelay;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveX * MoveSpeed, rb.linearVelocity.y);
    }


    private void SpawnSplash()
    {
        if (!isGrounded) return;

        GameObject splash = Instantiate(
            splashEffect,
            groundCheck.position,
            Quaternion.identity
        );

        Destroy(splash, 0.5f);

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(splashSound);
        }
    }




}
//public class prefabMovement : MonoBehaviour
//{
//    private Rigidbody2D rigidbody2D;
//    private float moveX;
//    private Vector2 movement; 

//    public float MoveSpeed = 5f;
//    public float JumpForce = 15f; 

//    public LayerMask Ground;
//    public bool isGrounded;
//    private Animator animator;

//    private void Start()
//    {
//        rigidbody2D = GetComponent<Rigidbody2D>();
//        isGrounded = true; // Assuming the player starts on the ground
//        animator = GetComponent<Animator>();
//    }

//    private void Update()
//    {
//        //isGrounded = false;
//        if (Input.GetKeyDown(KeyCode.Escape))
//        {
//            Time.timeScale = 0f;
//            SceneManager.LoadScene("MenuScene");
//        }
//        moveX = Input.GetAxisRaw("Horizontal");
//        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
//        {
//            rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, JumpForce);
//            isGrounded = false; // Player is now in the air
//        }

//        animator.SetBool("isGrounded", isGrounded);
//        animator.SetBool("isWalkingLeft", moveX < 0);
//        animator.SetBool("isWalkingRight", moveX > 0);

//    }

//    private void FixedUpdate()
//    {

//        rigidbody2D.linearVelocity = new Vector2(
//            moveX * MoveSpeed,
//            rigidbody2D.linearVelocity.y
//        );
//    }

//    private void OnCollisionStay2D(Collision2D collision)
//    {
//        if (((1 << collision.gameObject.layer) & Ground) != 0)
//        {
//            if (rigidbody2D.linearVelocity.y <= 0) // ONLY when falling or standing
//            {
//                isGrounded = true;
//            }
//        }
//    }

//    private void OnCollisionExit2D(Collision2D collision)
//    {
//        if (((1 << collision.gameObject.layer) & Ground) != 0)
//        {
//            isGrounded = false;
//        }
//    }
//}
