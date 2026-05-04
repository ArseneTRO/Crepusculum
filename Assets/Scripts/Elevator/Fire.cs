using UnityEngine;

public class Fire : MonoBehaviour
{
    private HealthSystem playerHP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHP = FindFirstObjectByType<PlayerMovement>().gameObject.GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerHP.Die();
        }
    }
}
