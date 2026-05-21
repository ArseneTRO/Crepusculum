using UnityEngine;

public class Fire : MonoBehaviour
{
    private HealthSystem playerHP;
    //Le feu tue le joueur
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
