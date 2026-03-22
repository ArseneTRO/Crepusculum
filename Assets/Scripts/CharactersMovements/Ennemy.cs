using System.Collections;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public SpriteRenderer mySpriteRenderer;
    public Rigidbody2D rb;
    public LifeBarSystem Pv;
    public HealthSystem PlayerHealthSystem;
    [SerializeField]
    private Transform myBase;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Path());
    }

    // Update is called once per frame
    void Update()
    {
        mySpriteRenderer.flipX = (Mathf.Sign(rb.linearVelocityX) < 0);
    }

    IEnumerator Path()
    {
        while (true)
        {
            float distance = Vector3.Distance(myBase.position, transform.position);

            if (distance > 5)
            {
                // Retour à la base en priorité
                Vector2 dirToTarget = (myBase.position - transform.position).normalized;
                rb.linearVelocity = dirToTarget * 7f;
                yield return null; // Attend juste la prochaine frame fraté
            }
            else
            {
                // Patrouille normale
                rb.linearVelocity = new Vector2(7, 0);
                yield return new WaitForSeconds(1);
                rb.linearVelocity = new Vector2(-7, 0);
                yield return new WaitForSeconds(1);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerHealthSystem.ChangeHealth(-1);
        }
    }
}
