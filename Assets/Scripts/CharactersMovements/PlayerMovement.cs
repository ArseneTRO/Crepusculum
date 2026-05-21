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
    public bool CinematicPlaying;
    public bool DialoguePlaying;

    public float moveSpeed;
    public float JumpForce;
    public float dashingPower;
    public float dashingTime;
    public float dashingCooldown;
    public PauseSystem pause;

    public Animator animator;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private TrailRenderer tr;
    [SerializeField]
    private SpriteRenderer mySpriteRenderer;
    [SerializeField]
    private DistanceJoint2D joint2D;
    public bool flowered;
    public LulupinMainScript lulupin;
    [SerializeField]
    private bool IsThisSceneIsJoint = false;
    [SerializeField]
    private LayerMask Ground;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    void Start()
    {
        isGrounded = false;
        pause = FindFirstObjectByType<PauseSystem>(FindObjectsInactive.Include);
        Ground = LayerMask.GetMask("Ground");
    }

    //Un gros gros script qui gère tout les déplacement du joueur. Pas spécialement compliqué, mais très complet surtout. Il contient le dash, les déplacement et le double jump, mais aussi des fonctions utilisées 
    //par d'autre script pour bloquer les commandes player par exemple
    public void Update()
    {
        if (pause.isPaused)
        {
            rb.linearVelocity = Vector2.zero; // pour que le player puisse pas bouger pendant les cinmatiques
            return;
        }
        if (rb.linearVelocity.x == 0)
        {
            animator.SetBool("IsWalking", false);
        }
        else
        animator.SetBool("IsWalking", true);
        
        

        if (CinematicPlaying)
        {
            if(!isGrounded)
            {
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);

            }
            else
            {
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
                rb.linearVelocity = Vector2.zero; // pour que le player puisse pas bouger pendant les cinmatiques
            }
            return;
        }
        
        if (DialoguePlaying)
        {
            rb.linearVelocity = Vector2.zero; // pour que le player puisse pas bouger pendant les cinmatiques
            return;
        }
        if (isDashing) // pour que le joueur puisse rien faire tant qu'il dash
        {
            return;
        }
        mySpriteRenderer.flipX = ((transform.localScale.x * dashingPower) < 0);


        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // Aller a droite
        {
            rb.linearVelocity = new UnityEngine.Vector2(moveSpeed, rb.linearVelocity.y);

            if (dashingPower < 0)
            {
                dashingPower = dashingPower * -1;
            }
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // Aller a guache
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
        
        
        var hit = Physics2D.Raycast(transform.position, Vector2.down, 0.03f, Ground);
        if (hit)
        {
            isGrounded = true;
            jumpsLeft = 2;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z)) // jump
        {
            if (isGrounded)
            {


                isGrounded = false; // Pour empecher de jump tant que le player n'est pas retomb� au

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

        if (!CinematicPlaying)
        {
            if (!IsThisSceneIsJoint)
            {
                joint2D.enabled = false;
                lulupin.distanceSystem = false;
            }
            else
            {
                joint2D.enabled = true;
                lulupin.distanceSystem = true;
            }
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
                
                rb.gravityScale = originalGravity;
                isDashing = false;
                yield return new WaitForSeconds(dashingCooldown);
                tr.emitting = false;
                canDash = true;
            }
        }
}
