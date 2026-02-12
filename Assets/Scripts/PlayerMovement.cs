using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isJumping = false;
    public bool isGrounded;
    public bool canDash = true;
    public bool isDashing;
    public bool isFrontflipping;
    public bool canFrontflip;

    public float moveSpeed;
    public float JumpForce;
    public float dashingPower;
    public float dashingTime;
    public float dashingCooldown;
    public float frontflippingTime;

    public Rigidbody2D rb;
    public TrailRenderer tr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing) // pour que le joueur puisse rien faire tant qu'il dash
        {
            return;
        }

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
                isGrounded = false; // Pour empecher de jump tant que le player n'est pas retombé au sol
                canFrontflip = true; // Pour que le player puisse faire un frontflip après un saut
                print("Jump !");
                rb.linearVelocity = new UnityEngine.Vector2(0, JumpForce);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && canDash) // c'est la couroutine du dash
        {
            StartCoroutine(Dash());
        }
        if (Input.GetKeyDown(KeyCode.Space) && canFrontflip) // c'est la couroutine du frontflip A REPARER
        {
            StartCoroutine(Frontflip());
        }

        IEnumerator Dash()
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
        IEnumerator Frontflip()
        {
            canFrontflip = false;
            isFrontflipping = true;
            float originalGravity = rb.gravityScale;
            tr.emitting = true;
            rb.linearVelocity = new UnityEngine.Vector2(0, JumpForce);
            yield return new WaitForSeconds(frontflippingTime);
            tr.emitting = false;
            isFrontflipping = false;
        }

    }


    
}
