using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PvSystem : MonoBehaviour
{
    public int HP;
    public Transform Checkpoint;
    public Transform Player;
    public Transform LifeBar;
    public void ChangeHP(int newAmount)
    {
        HP = newAmount;

        if (HP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Player.position = Checkpoint.position;
        HP = 3;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HP = 3;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < LifeBar.childCount; i++)
        {
            LifeBar.GetChild(i).gameObject.SetActive(HP>i);
        }
    }

    private void FixedUpdate()
    {
        if (HP <= 0)
        {
            Die();
        }
    }
}
