using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D myCollider;
    public HealthSystem playerHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            playerHealth.ChangeHealth(-2);
        }
    }
}
