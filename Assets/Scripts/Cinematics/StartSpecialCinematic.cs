using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class StartSpecialCinematic : MonoBehaviour
{


    [SerializeField]
    private List<CinematicManager.Cinematic> cinematicSteps;
    public CinematicManager cinematicManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CinematicManager.Instance.StartCinematic(cinematicSteps, false);
            Destroy(gameObject);
        }
    }


}
