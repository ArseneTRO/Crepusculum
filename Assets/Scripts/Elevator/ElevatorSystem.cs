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
    private float t;

    void Start()
    {
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GettingDown)
        {

            if (transform.position.y != minY)
            {
                t += (float)(0.5 * Time.deltaTime);
                transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, minY, t), 0);
                print("Je descends !");
                t = 0;
            }

        }
        if (!GettingDown)
        {
            if (transform.position.y != maxY)
            {
                t += (float)(0.5 * Time.deltaTime);
                transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, maxY, t), 0);
                print("Je monte !");
                t= 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     if(collision.CompareTag("Player"))
        {
            GettingDown = true;
            print("player entré");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
     if(collision.CompareTag("Player"))
        {
            GettingDown = false;
            print("player sorti");

        }
    }
}
