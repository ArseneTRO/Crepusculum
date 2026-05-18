using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;
using System.Collections;
using Unity.VisualScripting;

public class DestructableWall : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D myCollider; 
    [SerializeField]
    private BoxCollider2D playerBox;
    [SerializeField]
    private CircleCollider2D playercircle;
    public PlayerMovement player;
    private Animator myAnimator;

    void Start()
    {
        myAnimator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player.isDashing)
            {
                StartCoroutine(PassThroughWall());
            }
        }
    }
    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player.isDashing)
            {
                StartCoroutine(PassThroughWall());
            }
        }
    }


    IEnumerator PassThroughWall()
    {
        myAnimator.SetBool("TreeAsFallen", true);
        print("Cible d�truite");
        Physics2D.IgnoreCollision(playerBox, myCollider, true);
        Physics2D.IgnoreCollision(playercircle, myCollider, true);
        yield return new WaitForSeconds(0.5f);
        

    }
}
