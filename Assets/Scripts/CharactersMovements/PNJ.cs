using UnityEngine;

public class PNJ : MonoBehaviour
{
    private BoxCollider2D playerBox;
    private BoxCollider2D myBox;
    private CircleCollider2D playerCircle;
    private CircleCollider2D myCircle;
    //Ce script permet uniquement de retirer les collisions entre le joueur et le pnj, tout en concervant les collision avec le sol par exemple, pour rendre le pnj exploitable aux déplacements réalistes via cinématique tout de même
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
