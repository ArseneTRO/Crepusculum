using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int jumpsLeft;
    public bool isJumping = false;
    public bool isGrounded;
    public bool canDash = true;
    public bool isDashing;
    public bool flowered;
    public bool CinematicPlaying;

    public float moveSpeed;
    public float JumpForce;
    public float dashingPower;
    public float dashingTime;
    public float dashingCooldown;

    public Rigidbody2D rb;
    public TrailRenderer tr;
    public SpriteRenderer mySpriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isGrounded = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (CinematicPlaying)
        {
            rb.linearVelocity = Vector2.zero; // pour que le player puisse pas bouger pendant les cinématiques
            return;
        }
        if (isDashing) // pour que le joueur puisse rien faire tant qu'il dash
        {
            return;
        }
        mySpriteRenderer.flipX = (Mathf.Sign(rb.linearVelocityX) < 0);


        if (Input.GetKey(KeyCode.D)) // Aller à droite
        {
            rb.linearVelocity = new UnityEngine.Vector2(moveSpeed, rb.linearVelocity.y);

            if (dashingPower < 0)
            {
                dashingPower = dashingPower * -1;
            }
        }
        else if (Input.GetKey(KeyCode.A)) // Aller à guache
        {
            rb.linearVelocity = new UnityEngine.Vector2(-moveSpeed, rb.linearVelocity.y);
            if (dashingPower > 0)
            {
                dashingPower = dashingPower * -1;
            }
        }
        else
        {
            rb.linearVelocity = new UnityEngine.Vector2(0f, rb.linearVelocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space)) // jump
        {
            if (isGrounded)
            {
                isGrounded = false; // Pour empecher de jump tant que le player n'est pas retombé au 
                
                rb.linearVelocity = new UnityEngine.Vector2(0, JumpForce);
                print("Jump !");
                jumpsLeft -= 1;
            }
            else if (jumpsLeft == 1)
            {
                rb.linearVelocity = new UnityEngine.Vector2(0, JumpForce);
                print("DoubleJump !");
                jumpsLeft -= 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && canDash) // c'est la couroutine du dash
        {
            StartCoroutine(Dash());
        }



    }
        IEnumerator Dash()
        {
            if (flowered)
            {
            yield break;
            }
            else
            {
                canDash = false;
                isDashing = true;
                float originalGravity = rb.gravityScale;
                rb.gravityScale = 0f;
                rb.linearVelocity = new Vector2(transform.localScale.x * dashingPower, 0f);
                tr.emitting = true;
                yield return new WaitForSeconds(dashingTime);
                tr.emitting = false;
                rb.gravityScale = originalGravity;
                isDashing = false;
                yield return new WaitForSeconds(dashingCooldown);
                canDash = true;
            }
        }
}
