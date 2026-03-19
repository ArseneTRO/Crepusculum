using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class CinematicLauncher : MonoBehaviour
{

    [SerializeField]
    private List<CinematicElement> cinematicElements;
    [SerializeField]
    private bool launchOnStart;
    [SerializeField]
    private bool controlPlayer;

    void Start()
    {
        cinematicElements = transform.GetComponentsInChildren<CinematicElement>().ToList();  

        if(launchOnStart)
        {
            CinematicManager.Instance.StartCinematic(cinematicElements, controlPlayer);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CinematicManager.Instance.StartCinematic(cinematicElements, controlPlayer);
            Destroy(gameObject);
        }
    }
}
