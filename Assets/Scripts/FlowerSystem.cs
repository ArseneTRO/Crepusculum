using Unity.VisualScripting;
using UnityEngine;

public class FlowerSystem : PlayerMovement
{
    public CircleCollider2D flowerCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flowered)
        {
            base.moveSpeed = 2.5f;
            base.JumpForce = 5f;
            mySpriteRenderer.color = Color.gray;

        }
        else
        {
            mySpriteRenderer.color = Color.white;
            base.moveSpeed = 5f;
            base.JumpForce = 7f;
        }
        base.Update();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Flower"))
        {
            flowered = true;
        }
        else
        {
            return;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Flower"))
        {
            flowered = false;
        }
    }
}
