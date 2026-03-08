using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LifeBarSystem : MonoBehaviour
{
    public Transform LifeBar;
    public HealthSystem PlayerHealthSystem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
