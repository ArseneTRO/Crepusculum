using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float dashForce;
    public float dashDuration = 0.15f;
    public float jumpForce;
    public bool isJumping = false;
    public bool isGrounded;

    // input buffers
    private float horizontalInput;
    private bool jumpRequested;
    private bool dashRequested;

    // dash state
    private bool isDashing;
    private float dashTimer;
    private float dashDirection = 1f;

    void Start()
    {
        isGrounded = false;
        jumpRequested = false;
        dashRequested = false;
        isDashing = false;
    }

    void Update()
    {
        // Lire l'entrée dans Update pour ne pas rater les GetKeyDown
        if (Input.GetKey(KeyCode.D))
            horizontalInput = 1f;
        else if (Input.GetKey(KeyCode.A))
            horizontalInput = -1f;
        else
            horizontalInput = 0f;

        if (Input.GetKeyDown(KeyCode.Space))
            jumpRequested = true;

        if (Input.GetKeyDown(KeyCode.Q))
            dashRequested = true;
    }

    void FixedUpdate()
    {
        // Démarrer le dash si demandé et si au sol
        if (dashRequested && isGrounded && !isDashing)
        {
            dashRequested = false;
            isDashing = true;
            dashTimer = dashDuration;
            // Choisir la direction du dash : input si présent, sinon vers la droite
            dashDirection = horizontalInput != 0f ? Mathf.Sign(horizontalInput) : 1f;
            // Appliquer la vitesse de dash immédiatement
            rb.velocity = new Vector2(dashDirection * dashForce, rb.velocity.y);
            print("Dash !");
        }

        // Gérer la durée du dash
        if (isDashing)
        {
            dashTimer -= Time.fixedDeltaTime;
            if (dashTimer <= 0f)
            {
                isDashing = false;
            }
            else
            {
                // Maintenir la vitesse de dash pendant sa durée (empêche l'écrasement par le mouvement)
                rb.velocity = new Vector2(dashDirection * dashForce, rb.velocity.y);
            }
        }

        // Mouvement horizontal normal (seulement si on n'est pas en dash)
        if (!isDashing)
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        }

        // Appliquer le saut si demandé
        if (jumpRequested)
        {
            jumpRequested = false;
            if (isGrounded)
            {
                isGrounded = false;
                isJumping = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                print("Jump !");
            }
        }
    }
}