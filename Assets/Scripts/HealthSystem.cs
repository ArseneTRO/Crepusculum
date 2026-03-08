using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private int healthPoints;
    public int currentHealthPoints
    {
        get { return healthPoints; }
    }
    [SerializeField]
    private int maxHealthPoints = 3;
    public Transform checkpoint;
    public Transform transform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthPoints = maxHealthPoints;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeHealth(int newAmount)
    {
        healthPoints += newAmount;
        if (healthPoints <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (checkpoint == null)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = checkpoint.position;
            healthPoints = 3;
        }
    }
}
