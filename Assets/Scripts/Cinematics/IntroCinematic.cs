using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class IntroCinematic : MonoBehaviour
{


    [SerializeField]
    private List<CinematicManager.Cinematic> cinematicSteps;
    public CinematicManager cinematicManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CinematicManager.Instance.StartCinematic(cinematicSteps, true);
    }


}
