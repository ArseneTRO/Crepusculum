using UnityEngine;

public class CharactersBasics : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D rb;
    private SpriteRenderer mySpriteRenderer;
    public PauseSystem pause;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        pause = FindFirstObjectByType<PauseSystem>();
    }
    void Update()
    {
        if (pause.isPaused)
        {
            rb.linearVelocity = Vector2.zero; 
            return;
        }
        if (rb.linearVelocity.x == 0)
        {
            animator.SetBool("IsWalking", false);
        }
        else
        animator.SetBool("IsWalking", true);
        mySpriteRenderer.flipX = (Mathf.Sign(rb.linearVelocityX) > 0);
    }
}
