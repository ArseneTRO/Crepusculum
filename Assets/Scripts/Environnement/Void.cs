using Unity.VisualScripting;
using UnityEngine;

public class Void : MonoBehaviour
{
    public Collider2D myCollider;
    public Collider2D PlayerCollider;
    public HealthSystem HealthSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HealthSystem = GameObject.FindWithTag("Player").GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            HealthSystem.Die();
        }
    }
}
