using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LifeBarSystem : MonoBehaviour
{
    public Transform LifeBar;
    public HealthSystem PlayerHealthSystem;

    //système de barre de vie
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < LifeBar.childCount; i++)
        {
            LifeBar.GetChild(i).gameObject.SetActive(PlayerHealthSystem.currentHealthPoints>i);
        }
    }
}
