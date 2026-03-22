using UnityEngine;

public class CharactersBasics : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D rb;
    private SpriteRenderer mySpriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.linearVelocity.x == 0)
        {
            animator.SetBool("IsWalking", false);
        }
        else
        animator.SetBool("IsWalking", true);
        mySpriteRenderer.flipX = (Mathf.Sign(rb.linearVelocityX) > 0);
    }
}
