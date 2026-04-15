using System.Collections;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public SpriteRenderer mySpriteRenderer;
    public Rigidbody2D rb;
    public LifeBarSystem Pv;
    [SerializeField]
    private Transform myBase;
    public PauseSystem pause;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Path());

    }

    // Update is called once per frame
    void Update()
    {
        if (pause.isPaused)
        {
            return;
        }
        mySpriteRenderer.flipX = (Mathf.Sign(rb.linearVelocityX) < 0);
    }

    IEnumerator Path()
    {
        while (true)
        {
            float distance = Vector3.Distance(myBase.position, transform.position);

            if (distance > 5)
            {
                transform.position = myBase.position;
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
        var playerHealth = collision.gameObject.GetComponent<HealthSystem>();
        if (playerHealth!= null)
        {
            playerHealth.ChangeHealth(-1);
        }
    }
}
