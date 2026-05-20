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
    private bool _Die;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthPoints = maxHealthPoints;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
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
            StartCoroutine(PlayerDie());
        }
    }

    IEnumerator PlayerDie()
    {
        if (_Die)
        {
            yield break;
        }
        else
        {
            _Die = true;
                if (playerAnimator != null)
            {

                rb.simulated = false;
                playerAnimator.SetBool("isDead", true);
                yield return new WaitForSeconds(0.5f);
                playerAnimator.SetBool("isDead", false);
                yield return new WaitForSeconds(1.7f);
                rb.simulated = true;
            }
            transform.position = checkpoint.position;
            if (SceneManager.GetActiveScene().name == "Level4")
            {
                SceneManager.LoadScene("Level4");
            }
            healthPoints = 3;
            _Die = false;
        }
        
    }
}
