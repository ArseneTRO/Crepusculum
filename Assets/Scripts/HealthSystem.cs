using System.Collections;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private int healthPoints;
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private Rigidbody2D rb;  
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
            rb = this.gameObject.GetComponent<Rigidbody2D>();
            StartCoroutine(PlayerDie());
        }
    }

    IEnumerator PlayerDie()
    {
        if (playerAnimator != null)
        {
            rb.linearVelocity = Vector2.zero;
            playerAnimator.SetBool("isDead", true);
            yield return new WaitForSeconds(0.5f);
            playerAnimator.SetBool("isDead", false);
            yield return new WaitForSeconds(0.5f);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y);
        }
        transform.position = checkpoint.position;
        healthPoints = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
