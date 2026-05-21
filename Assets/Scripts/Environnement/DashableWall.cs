using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;
using System.Collections;
using Unity.VisualScripting;

public class DashableWall : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D myCollider; 
    [SerializeField]
    private BoxCollider2D playerBox;
    [SerializeField]
    private CircleCollider2D playercircle;
    public PlayerMovement player;

    // Murs dashable du niveau 2
    void Start()
    {
        
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
        print("J'ai hit avec isDashing");
        Physics2D.IgnoreCollision(playerBox, myCollider, true);
        Physics2D.IgnoreCollision(playercircle, myCollider, true);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(playerBox, myCollider, false);
        Physics2D.IgnoreCollision(playercircle, myCollider, false);
    }
}
