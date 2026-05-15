using UnityEngine;

public class PNJ : MonoBehaviour
{
    private BoxCollider2D playerBox;
    private BoxCollider2D myBox;
    private CircleCollider2D playerCircle;
    private CircleCollider2D myCircle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerBox = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>(); 
        myBox = this.gameObject.GetComponent<BoxCollider2D>();
        playerCircle = GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>();
        myCircle = this.gameObject.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(playerBox, myBox);
        Physics2D.IgnoreCollision(playerCircle, myCircle);
        Physics2D.IgnoreCollision(playerCircle, myBox);
        Physics2D.IgnoreCollision(playerBox, myCircle);
    }
}
