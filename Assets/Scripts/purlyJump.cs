using UnityEngine;

public class purlyJump : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float jumpForce = 5f;

    private float playerHalfHeight;


    private void Start()
    {
        playerHalfHeight = spriteRenderer.bounds.extents.y;
    }


    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector2.down * 1f, Color.red);

        if (Input.GetKeyDown(KeyCode.UpArrow) && GetIsGrounded())
        {
            Jump();
        }
    }

    private bool GetIsGrounded()
    {
        // Check if there's ground below the player using a raycast
        return Physics2D.Raycast(transform.position, Vector2.down, playerHalfHeight + 0.1f, LayerMask.GetMask("Ground"));
       
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
