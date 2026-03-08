using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    public PlayerMovement playerMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            playerMovement.isGrounded = true;  // Pour jump, etc.
            playerMovement.jumpsLeft = 2;
            print("Grounded !");
        }
    }
}
