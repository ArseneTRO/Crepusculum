using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ElevatorSystem : MonoBehaviour
{
    [SerializeField]
    private int maxY;
    [SerializeField]
    private int minY;
    private bool GettingDown = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GettingDown)
        {

            while (transform.position.y == maxY)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, 0);
                print("Je descends !");
            }

        }
        if (!GettingDown)
        {
            while (transform.position.y != maxY)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
                print("Je Monte !");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     if(collision.CompareTag("Player"))
        {
            GettingDown = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
     if(collision.CompareTag("Player"))
        {
            GettingDown = true;
        }
    }
}
