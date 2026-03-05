using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public SpriteRenderer mySpriteRenderer;
    public Rigidbody2D rb;
    public PvSystem Pv;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Pv.HP -= 1;
        }
    }
}
