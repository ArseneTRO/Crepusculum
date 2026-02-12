using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Collider2D MyCollider;

    public Transform respawn;
    public Transform myTransform;
    public SpriteRenderer myAspect;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            respawn.position = myTransform.position;
            myAspect.color = Color.green;
        }
    }

}
