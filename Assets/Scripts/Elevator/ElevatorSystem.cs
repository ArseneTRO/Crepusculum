using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ElevatorSystem : MonoBehaviour
{
    [SerializeField]
    private int maxY;
    [SerializeField]
    private int minY;
    [SerializeField]
    private float duration;
    private bool GettingDown = false;
    private float t;

    void Start()
    {
        t = 0;
    }

    //Système d'ascenseur. Si le joueur est là, l'ascenseur descend de plus en plus doucement à l'aide d'un lerp, sinon il monte
    void Update()
    {
        if (GettingDown)
        {

            if (transform.position.y != minY)
            {
                t += (float)(duration * Time.deltaTime);
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
