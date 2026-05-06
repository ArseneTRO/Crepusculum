using UnityEngine;

public class SimpleDamagePlatform : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D myCollider;
    public HealthSystem playerHealth;
    [SerializeField]
    public int damages;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.ChangeHealth(-damages);
        }
    }
}
