using UnityEngine;

public class FloweredEnemisystem : MonoBehaviour
{
    public FlowerSystem FlowerSystem;
    private CircleCollider2D myCollider;
    public PauseSystem pause;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pause = FindFirstObjectByType<PauseSystem>(FindObjectsInactive.Include);
    }

    // Update is called once per frame
    void Update()
    {
        if (pause.isPaused)
        {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (FlowerSystem.flowerObject != this.gameObject)
            {
                FlowerSystem.flowerObject = this.gameObject;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (FlowerSystem.flowerObject == this.gameObject)
            {
                FlowerSystem.flowerObject = null;
            }
        }
    }


}
